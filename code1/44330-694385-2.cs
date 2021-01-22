    /// <summary>
        /// Reads a TextRange (DataFormats.Rtf) from the stream.
        /// </summary>
        /// <param name="stream">The stream to be read from.</param>
        /// <returns>The TextRange (DataFormats.Rtf) that was read from the stream.</returns>
        public static TextRange ReadTextRange(FileStream stream)
        {
            long startPos = stream.Position;
            int length = -1;
            int count = 0;
            int previousByte = 0;
            int currentByte = 0;
            //set previousByte to give the current one something to compare to
            previousByte = stream.ReadByte();
            //parse the file counting the { and } to find the end of the rtf portion of the file.
            while (count > 0 || length < 1)
            {
                length++;
                stream.Position = startPos + length;
                currentByte = stream.ReadByte();
                if (previousByte != 92) // not '\' so check to see if '{' or '}' is currentByte
                {
                    if (currentByte == 123) // '{' increase count
                        count++;
                    else if (currentByte == 125) // '}' decrease count
                        count--;
                }
                previousByte = currentByte;
            }
            //save finish position to move to later
            long finishPos = stream.Position;
            //reset stream position to start at beginning of rtf
            stream.Position = startPos;
            //read the rtf portion of the file into a byte[]
            byte[] content = new byte[length];
            stream.Read(content, 0, length);
            //put the byte[] into a memory stream
            MemoryStream memStream = new MemoryStream(content);
            FlowDocument doc = new FlowDocument();
            TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
            //have the TextRange read from the memorystream
            range.Load(memStream, System.Windows.DataFormats.Rtf);
            memStream.Close();
            //set the position to after the rtf portion of the file
            stream.Position = finishPos;
            return range;
        }
