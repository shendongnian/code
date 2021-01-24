            public static string LoadRtf(string rtf, TextRange range)
            {
                if (string.IsNullOrEmpty(rtf))
                    return "";
    
                using (MemoryStream rtfMemoryStream = new MemoryStream())
                {
                    using (StreamWriter rtfStreamWriter = new StreamWriter(rtfMemoryStream))
                    {
                        rtfStreamWriter.Write(rtf);
                        rtfStreamWriter.Flush();
                        rtfMemoryStream.Seek(0, SeekOrigin.Begin);
    
                        range.Load(rtfMemoryStream, DataFormats.Rtf);
                    }
                }
    
                return range.Text;
            }
