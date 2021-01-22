        public static string PrettyPrintXML(XDocument document)
        {
            string Result = "";
            using (MemoryStream mStream = new MemoryStream())
            {
                using (XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode))
                {
                    writer.Formatting = Formatting.Indented; // <<--- this does the trick
                    // Write the XML into a formatting XmlTextWriter
                    document.WriteTo(writer);
                    // change the memory stream from write to read
                    writer.Flush();
                    writer.Close();
                    mStream.Flush();
                    mStream.Position = 0;//rewind
                    // Read MemoryStream contents into a StreamReader.
                    using (StreamReader sReader = new StreamReader(mStream))
                    {
                        // Extract the text from the StreamReader.
                        Result = sReader.ReadToEnd();
                    }
                }// <-- here the writer may be Disposed
            }
            return Result;
        }
