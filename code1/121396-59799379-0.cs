        enum CSVMode
        {
            CLOSED = 0,
            OPENED_RAW = 1,
            OPENED_QUOTE = 2
        }
        private List<string> ParseCSV(string input)
        {
            List<string> results;
            CSVMode mode;
            
            char[] letters;
            string content;
            mode = CSVMode.CLOSED;
            content = "";
            results = new List<string>();
            letters = input.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                char letter = letters[i];
                char nextLetter = '\0';
                
                if(i < letters.Length - 1)
                    nextLetter = letters[i + 1];
                // If its a quote character
                if (letter == '"')
                {
                    // If that next letter is a quote
                    if (nextLetter == '"' && mode == CSVMode.OPENED_QUOTE)
                    {
                        // Then this quote is escaped and should be added to the content
                        content += letter;
                        // Skip the escape character
                        i++;
                        continue;
                    }
                    else
                    {
                        // otherwise its not an escaped quote and is an opening or closing one
                        // Character is skipped
                        // If it was open, then close it
                        if (mode == CSVMode.OPENED_QUOTE)
                        {
                            results.Add(content);
                            // reset the content
                            content = "";
                            mode = CSVMode.CLOSED;
                            // If there is a next letter available
                            if (nextLetter != '\0')
                            {
                                // If it is a comma
                                if (nextLetter == ',')
                                {
                                    i++;
                                    continue;
                                }
                                else
                                {
                                    throw new Exception("Expected comma. Found: " + nextLetter);
                                }
                            }
                        }
                        else if (mode == CSVMode.OPENED_RAW)
                        {
                            // If it was opened raw, then just add the quote 
                            content += letter;
                        }
                        else if (mode == CSVMode.CLOSED)
                        {
                            // Otherwise open it as a quote 
                            mode = CSVMode.OPENED_QUOTE;
                        }
                    }
                }
                // If its a comma seperator
                else if (letter == ',')
                {
                    // If in quote mode
                    if (mode == CSVMode.OPENED_QUOTE)
                    {
                        // Just read it
                        content += letter;
                    }
                    // If raw, then close the content
                    else if (mode == CSVMode.OPENED_RAW)
                    {
                        results.Add(content);
                        content = "";
                        mode = CSVMode.CLOSED;
                    }
                    // If it was closed, then open it raw
                    else if (mode == CSVMode.CLOSED)
                    {
                        mode = CSVMode.OPENED_RAW;
                    }
                }
                else
                {
                    // If opened quote, just read it
                    if (mode == CSVMode.OPENED_QUOTE)
                    {
                        content += letter;
                    }
                    // If opened raw, then read it
                    else if (mode == CSVMode.OPENED_RAW)
                    {
                        content += letter;
                    }
                    // It closed, then open raw
                    else if (mode == CSVMode.CLOSED)
                    {
                        mode = CSVMode.OPENED_RAW;
                        content += letter;
                    }                    
                }
            }
            // If it was still reading when the buffer finished
            if (mode != CSVMode.CLOSED)
            {
                results.Add(content);
            }
            return results;
        }
        private string FormatCSV(List<string> parts)
        {
            string result = "";
            foreach (string s in parts)
            {
                if (result.Length > 0)
                    result += ",";
                if (s.Length > 0)
                {
                    result += "\"" + s.Replace("\"", "\"\"") + "\"";
                }
                else
                {
                    // cannot output double quotes since its considered an escape for a quote
                    result += ",";
                }
            }
            return result;
        }
