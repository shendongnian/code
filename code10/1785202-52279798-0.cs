    string filepaht="your xml path";
    string data=File.ReadAllText(filepath);
    Stream newdata=null;
     StreamReader strReader = null;
                try
                {
                    //Lookup the encoding. If we not find the specified encoding, we use UTF-8.
                   Encoding  messageEncoding = Encoding.UTF8;
                    strReader = new StreamReader(data, messageEncoding);
                    // Read the entire message into a string. Not a good idea if you receive largeish messages. Then you ned a bufferen approach
                    string msgBodyContentString = strReader.ReadToEnd();
                    string[] searchStrings = SearchString.Split(STRING_SEPARATOR.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string[] replaceStrings = ReplaceString.Split(STRING_SEPARATOR.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    for (int index = 0; index <= (searchStrings.Length -1); index++)
                    {
                        string oldValue = searchStrings[index];
                        if (!string.IsNullOrEmpty(oldValue))
                        {
                            //default to string empty if we do not have a replace value
                            string newValue = string.Empty;
                            if (index <= replaceStrings.Length - 1)
                                newValue = replaceStrings[index];
                            msgBodyContentString = msgBodyContentString.Replace(Regex.Unescape(oldValue), Regex.Unescape(newValue));
                        }
                    }
                    // Convert to bytes
                    byte[] msgBodyContentBytes = Encoding.Unicode.GetBytes(msgBodyContentString);
                    // Convert the encoding
                    byte[] msgBodyContentBytesConverted = Encoding.Convert(Encoding.Unicode, messageEncoding, msgBodyContentBytes);
                    // Write new stream back
                    newdata = new MemoryStream(msgBodyContentBytesConverted);                                        
                }
    var inputXml = XDocument.ReadFrom(newdata);
