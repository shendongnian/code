            string csv = "543472,\"36743721\",\"Rutois, a.s.\",\"151\",\"some name\",\"01341\",55,\"112\",1"; 
            const string COMMA_TOKEN = "[COMMA]";
            string[] values;
            bool inQuotes = false;
            StringBuilder cleanedCsv = new StringBuilder();
            foreach (char c in csv)
            {
                if (c == '\"')
                    inQuotes = !inQuotes;  //work out if inside a quoted string or not
                else
                {
                    //Replace commas in quotes with a token
                    if (inQuotes && c == ',')
                        cleanedCsv.Append(COMMA_TOKEN);
                    else
                        cleanedCsv.Append(c);
                }
            }
            values = cleanedCsv.ToString().Split(',');
            //Put the commas back
            for (int i = 0; i < values.Length; i++)
                values[i] = values[i].Replace(COMMA_TOKEN, ",");
