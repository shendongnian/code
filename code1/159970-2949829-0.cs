    class XmlParser {
    
        private byte[] buffer = new byte[0];
    
        public int Length { 
            get {
                return buffer.Length;
            }
        }
    
        // Append new binary data to the internal data buffer...
        public XmlParser Append(byte[] buffer2) {
            if (buffer2 != null && buffer2.Length > 0) {
                // I know, its not an efficient way to do this.
                // The EofMemoryStream should handle a List<byte[]> ...
                byte[] new_buffer = new byte[buffer.Length + buffer2.Length];
                buffer.CopyTo(new_buffer, 0);
                buffer2.CopyTo(new_buffer, buffer.Length);
                buffer = new_buffer;
            }
            return this;
        }
    
        // MemoryStream which returns the last byte of the buffer individually,
        // so that we know that the buffering XmlReader really locked at the last
        // byte of the stream.
        // Moreover there is an EOF marker.
        private class EofMemoryStream: Stream {
            public bool EOF { get; private set; }
            private MemoryStream mem_;
    
            public override bool CanSeek {
                get {
                    return false;
                }
            }
            public override bool CanWrite {
                get {
                    return false;
                }
            }
            public override bool CanRead {
                get {
                    return true;
                }
            }
            public override long Length {
                get { 
                    return mem_.Length; 
                }
            }
            public override long Position {
                get {
                    return mem_.Position;
                }
                set {
                    throw new NotSupportedException();
                }
            }
            public override void Flush() {
                mem_.Flush();
            }
            public override long Seek(long offset, SeekOrigin origin) {
                throw new NotSupportedException();
            }
            public override void SetLength(long value) {
                throw new NotSupportedException();
            }
            public override void Write(byte[] buffer, int offset, int count) {
                throw new NotSupportedException();
            }
            public override int Read(byte[] buffer, int offset, int count) {
                count = Math.Min(count, Math.Max(1, (int)(Length - Position - 1)));
                int nread = mem_.Read(buffer, offset, count);
                if (nread == 0) {
                    EOF = true;
                }
                return nread;
            }
            public EofMemoryStream(byte[] buffer) {
                mem_ = new MemoryStream(buffer, false);
                EOF = false;
            }
            protected override void Dispose(bool disposing) {
                mem_.Dispose();
            }
    
        }
    
        // Parses the first xml message from the stream.
        // If the first message is not yet complete, it returns null.
        // If the buffer contains non-wellformed xml, it ~should~ throw an exception.
        // After reading an xml message, it pops the data from the byte array.
        public Message deserialize() {
            if (buffer.Length == 0) {
                return null;
            }
            Message message = null;
    
            Encoding encoding = Message.default_encoding;
            //string xml = encoding.GetString(buffer);
    
            using (EofMemoryStream sbuffer = new EofMemoryStream (buffer)) {
    
                XmlDocument xmlDocument = null;
                XmlReaderSettings settings = new XmlReaderSettings();
    
                int LineNumber = -1;
                int LinePosition = -1;
                bool truncate_buffer = false;
    
                using (XmlReader xmlReader = XmlReader.Create(sbuffer, settings)) {
                    try {
                        // Read to the first node (skipping over some element-types.
                        // Don't use MoveToContent here, because it would skip the
                        // XmlDeclaration too...
                        while (xmlReader.Read() &&
                               (xmlReader.NodeType==XmlNodeType.Whitespace || 
                                xmlReader.NodeType==XmlNodeType.Comment)) {
                        };
                            
                        // Check for XML declaration.
                        // If the message has an XmlDeclaration, extract the encoding.
                        switch (xmlReader.NodeType) {
                            case XmlNodeType.XmlDeclaration: 
                                while (xmlReader.MoveToNextAttribute()) {
                                    if (xmlReader.Name == "encoding") {
                                        encoding = Encoding.GetEncoding(xmlReader.Value);
                                    }
                                }
                                xmlReader.MoveToContent();
                                xmlReader.Read();
                                break;
                        }
    
                        // Move to the first element.
                        xmlReader.MoveToContent();
    
                        // Read the entire document.
                        xmlDocument = new XmlDocument();
                        xmlDocument.Load(xmlReader.ReadSubtree());
                    } catch (XmlException e) {
                        // The parsing of the xml failed. If the XmlReader did
                        // not yet look at the last byte, it is assumed that the
                        // XML is invalid and the exception is re-thrown.
                        if (sbuffer.EOF) {
                            return null;
                        }
                        throw e;
                    }
    
                    {
                        // Try to serialize an internal data structure using XmlSerializer.
                        Type type = null;
                        try {
                            type = Type.GetType("my.namespace." + xmlDocument.DocumentElement.Name);
                        } catch (Exception e) {
                            // No specialized data container for this class found...
                        }
                        if (type == null) {
                            message = new Message();
                        } else {
                            // TODO: reuse the serializer...
                            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(type);
                            message = (Message)ser.Deserialize(new XmlNodeReader(xmlDocument));
                        }
                        message.doc = xmlDocument;
                    }
    
                    // At this point, the first XML message was sucessfully parsed.
    
                    // Remember the lineposition of the current end element.
                    IXmlLineInfo xmlLineInfo = xmlReader as IXmlLineInfo;
                    if (xmlLineInfo != null && xmlLineInfo.HasLineInfo()) {
                        LineNumber = xmlLineInfo.LineNumber;
                        LinePosition = xmlLineInfo.LinePosition;
                    }
    
    
                    // Try to read the rest of the buffer.
                    // If an exception is thrown, another xml message appears.
                    // This way the xml parser could tell us that the message is finished here.
                    // This would be prefered as truncating the buffer using the line info is sloppy.
                    try {
                        while (xmlReader.Read()) {
                        }
                    } catch {
                        // There comes a second message. Needs workaround for trunkating.
                        truncate_buffer = true;
                    }
                }
                if (truncate_buffer) {
                    if (LineNumber < 0) {
                        throw new Exception("LineNumber not given. Cannot truncate xml buffer");
                    }
                    // Convert the buffer to a string using the encoding found before 
                    // (or the default encoding).
                    string s = encoding.GetString(buffer);
    
                    // Seek to the line.
                    int char_index = 0;
                    while (--LineNumber > 0) {
                        // Recognize \r , \n , \r\n as newlines...
                        char_index = s.IndexOfAny(new char[] {'\r', '\n'}, char_index);
                        // char_index should not be -1 because LineNumber>0, otherwise an RangeException is 
                        // thrown, which is appropriate.
                        char_index++;
                        if (s[char_index-1]=='\r' && s.Length>char_index && s[char_index]=='\n') {
                            char_index++;
                        }
                    }
                    char_index += LinePosition - 1;
    
                    var rgx = new System.Text.RegularExpressions.Regex(xmlDocument.DocumentElement.Name + "[ \r\n\t]*\\>");
                    System.Text.RegularExpressions.Match match = rgx.Match(s, char_index);
                    if (!match.Success || match.Index != char_index) {
                        throw new Exception("could not find EndElement to truncate the xml buffer.");
                    }
                    char_index += match.Value.Length;
    
                    // Convert the character offset back to the byte offset (for the given encoding).
                    int line1_boffset = encoding.GetByteCount(s.Substring(0, char_index));
    
                    // remove the bytes from the buffer.
                    buffer = buffer.Skip(line1_boffset).ToArray();
                } else {
                    buffer = new byte[0];
                }
            }
            return message;
        }
    }
    
