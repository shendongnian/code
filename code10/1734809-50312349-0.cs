        private static String[] ReadCSVRow( TextReader csv )
        {
            int ch;
            Boolean bInQuote = false;
            StringBuilder builder = new StringBuilder(128);
            List<String> columns = new List<String>();
            while ((ch = csv.Read()) != -1)
            {
                if (builder.Length == 0 && !bInQuote)
                {
                    if (ch == '\"')
                        bInQuote = true;
                    else if (ch == ',')
                    {
                        // add an empty string
                        columns.Add("");
                    }
                    else if (ch == '\n')
                    {
                        // return current columns
                        columns.Add("");
                        return columns.ToArray();
                    }
                    else if (ch != '\r')
                    {
                        // start a new column
                        builder.Append((char)ch);
                    }
                }
                else if (bInQuote)
                {
                    // we have started our column with a quote
                    if (ch == '\"')
                    {
                        // peek to see if this is double.
                        int next = csv.Peek();
                        if (next == '\"')
                        {
                            // read it.
                            csv.Read();
                            // add it
                            builder.Append('\"');
                        }
                        else 
                        {
                            // no longer in quotes. next SHOULD be a comma or end of file.
                            bInQuote = false;
                        }
                    }
                    else
                    {
                        builder.Append((char)ch);
                    }
                }
                else
                {
                    if (ch == ',')
                    {
                        // add our column and go to next
                        columns.Add(builder.ToString());
                        builder.Clear();
                    }
                    else if (ch == '\n')
                    {
                        // add column and return.
                        columns.Add(builder.ToString());
                        builder.Clear();
                        return columns.ToArray();
                    }
                    else if (ch != '\r')   // skip line feeds if not in quotes.
                    {
                        builder.Append((char)ch);
                    }
                }
            }
            //
            // we hit end of file without a new line. If we have data, return it, otherwise null.
            if (builder.Length > 0)
                columns.Add(builder.ToString());
            if (columns.Count == 0)
                return null;
            return columns.ToArray();
        }
