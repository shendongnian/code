    using (TextFieldParser lcsvReader = new TextFieldParser(new MemoryStream(<FILE_BYTES>), Encoding.Default))
                            {
                                lcsvReader.Delimiters = new string[2] { ",", "\t" };
                                lcsvReader.HasFieldsEnclosedInQuotes = true;
                                lcsvReader.TrimWhiteSpace = true;
                                while (!lcsvReader.EndOfData)
                                {
                                    string[] fields = lcsvReader.ReadFields();
                                    //fields -- Actual field in CSV
                                }
                                lcsvReader.Close();
                            }
