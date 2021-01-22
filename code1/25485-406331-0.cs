    using System;
    using System.IO;
    using System.Text;
    namespace MyProject
    {
        class StreamReaderExt : StreamReader
        {
        
            public StreamReaderExt(Stream s, Encoding e) : base(s, e)
            {            
            }
            /// <summary>
            /// Reads a line of characters terminated by CR+LF from the current stream and returns the data as a string
            /// </summary>
            /// <param name="maxLineLength">Maximum allowed line length</param>
            /// <exception cref="System.IO.IOException" />
            /// <exception cref="System.InvalidOperationException">When string read by this method exceeds the maximum allowed line length</exception>
            /// <returns></returns>
            public string ReadLineCRLF(int maxLineLength)
            {
                StringBuilder currentLine = new StringBuilder(maxLineLength);
                int i;
                bool foundCR = false;
                bool readData = false;
                while ((i = Read()) > 0)
                {
                    readData = true;
                    char c = (char)i;
                    if (foundCR)
                    {
                        if (c == '\r')
                        {
                            // If CR was found before , and the next character is also CR,
                            // adding previously skipped CR to the result string
                            currentLine.Append('\r');
                            continue;
                        }
                        else if (c == '\n')
                        {
                            // LF found, finished reading the string
                            return currentLine.ToString();
                        }
                        else
                        {
                            // If CR was found before , but the next character is not LF,
                            // adding previously skipped CR to the result string
                            currentLine.Append('\r');
                            foundCR = false;
                        }
                    }
                    else // CR not found
                    {
                        if (c == '\r')
                        {
                            foundCR = true;
                            continue;
                        }
                    }
                    currentLine.Append((char)c);
                    if (currentLine.Length > maxLineLength)
                    {
                        throw new InvalidOperationException("Max line length exceeded");
                    }
                }
                if (foundCR)
                {
                    // If CR was found before, and the end of the stream has been reached, appending the skipped CR character
                    currentLine.Append('\r');
                }
                if (readData)
                {
                    return currentLine.ToString();
                }
                // End of the stream reached
                return null;
            }
        }
    }
