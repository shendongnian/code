       public static string[] CSVRowToStringArray(string r, char fieldSep = ',', char stringSep = '\"')  {
                bool bolQuote = false;
                StringBuilder bld = new StringBuilder();
                List<string> retAry = new List<string>();
        
                foreach (char c in r.ToCharArray())
                    if ((c == fieldSep && !bolQuote))
                    {
                        retAry.Add(bld.ToString());
                        bld.Clear();
                    }
                    else
                        if (c == stringSep)
                            bolQuote = !bolQuote;
                        else
                            bld.Append(c);
        
                /* to solve the last element problem */
                retAry.Add(bld.ToString()); /* added this line */
                return retAry.ToArray();
            }
