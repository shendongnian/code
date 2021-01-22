    public static DataTable CsvToDataTable(string strFilePath)
        {
            if (File.Exists(strFilePath))
            {
                string[] Lines;
                string CSVFilePathName = strFilePath;
                Lines = File.ReadAllLines(CSVFilePathName);
                while (Lines[0].EndsWith(","))
                {
                    Lines[0] = Lines[0].Remove(Lines[0].Length - 1);
                }
                string[] Fields;
                Fields = Lines[0].Split(new char[] { ',' });
                int Cols = Fields.GetLength(0);
                DataTable dt = new DataTable();
                //1st row must be column names; force lower case to ensure matching later on.
                for (int i = 0; i < Cols; i++)
                    dt.Columns.Add(Fields[i], typeof(string));
                DataRow Row;
                int rowcount = 0;
                try
                {
                    string[] ToBeContinued = new string[]{};
                    bool lineToBeContinued = false;
                    for (int i = 1; i < Lines.GetLength(0); i++)
                    {
                        if (!Lines[i].Equals(""))
                        {
                            Fields = Lines[i].Split(new char[] { ',' });
                            string temp0 = string.Join("", Fields).Replace("\"\"", "");
                            int quaotCount0 = temp0.Count(c => c == '"');
                            if (Fields.GetLength(0) < Cols || lineToBeContinued || quaotCount0 % 2 != 0)
                            {
                                if (ToBeContinued.GetLength(0) > 0)
                                {
                                    ToBeContinued[ToBeContinued.Length - 1] += "\n" + Fields[0];
                                    Fields = Fields.Skip(1).ToArray();
                                }
                                string[] newArray = new string[ToBeContinued.Length + Fields.Length];
                                Array.Copy(ToBeContinued, newArray, ToBeContinued.Length);
                                Array.Copy(Fields, 0, newArray, ToBeContinued.Length, Fields.Length);
                                ToBeContinued = newArray;
                                string temp = string.Join("", ToBeContinued).Replace("\"\"", "");
                                int quaotCount = temp.Count(c => c == '"');
                                if (ToBeContinued.GetLength(0) >= Cols && quaotCount % 2 == 0 )
                                {
                                    Fields = ToBeContinued;
                                    ToBeContinued = new string[] { };
                                    lineToBeContinued = false;
                                }
                                else
                                {
                                    lineToBeContinued = true;
                                    continue;
                                }
                            }
                            //modified by Teemo @2016 09 13
                            //handle ',' and '"'
                            //Deserialize CSV following Excel's rule:
                            // 1: If there is commas in a field, quote the field.
                            // 2: Two consecutive quotes indicate a user's quote.
                            List<int> singleLeftquota = new List<int>();
                            List<int> singleRightquota = new List<int>();
                            
                            //combine fileds if number of commas match
                            if (Fields.GetLength(0) > Cols) 
                            {
                                bool lastSingleQuoteIsLeft = true;
                                for (int j = 0; j < Fields.GetLength(0); j++)
                                {
                                    bool leftOddquota = false;
                                    bool rightOddquota = false;
                                    if (Fields[j].StartsWith("\"")) 
                                    {
                                        int numberOfConsecutiveQuotes = 0;
                                        foreach (char c in Fields[j]) //start with how many "
                                        {
                                            if (c == '"')
                                            {
                                                numberOfConsecutiveQuotes++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        if (numberOfConsecutiveQuotes % 2 == 1)//start with odd number of quotes indicate system quote
                                        {
                                            leftOddquota = true;
                                        }
                                    }
                                    if (Fields[j].EndsWith("\""))
                                    {
                                        int numberOfConsecutiveQuotes = 0;
                                        for (int jj = Fields[j].Length - 1; jj >= 0; jj--)
                                        {
                                            if (Fields[j].Substring(jj,1) == "\"") // end with how many "
                                            {
                                                numberOfConsecutiveQuotes++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        
                                        if (numberOfConsecutiveQuotes % 2 == 1)//end with odd number of quotes indicate system quote
                                        {
                                            rightOddquota = true;
                                        }
                                    }
                                    if (leftOddquota && !rightOddquota)
                                    {
                                        singleLeftquota.Add(j);
                                        lastSingleQuoteIsLeft = true;
                                    }
                                    else if (!leftOddquota && rightOddquota)
                                    {
                                        singleRightquota.Add(j);
                                        lastSingleQuoteIsLeft = false;
                                    }
                                    else if (Fields[j] == "\"") //only one quota in a field
                                    {
                                        if (lastSingleQuoteIsLeft)
                                        {
                                            singleRightquota.Add(j);
                                        }
                                        else
                                        {
                                            singleLeftquota.Add(j);
                                        }
                                    }
                                }
                                if (singleLeftquota.Count == singleRightquota.Count)
                                {
                                    int insideCommas = 0;
                                    for (int indexN = 0; indexN < singleLeftquota.Count; indexN++)
                                    {
                                        insideCommas += singleRightquota[indexN] - singleLeftquota[indexN];
                                    }
                                    if (Fields.GetLength(0) - Cols >= insideCommas) //probabaly matched
                                    {
                                        int validFildsCount = insideCommas + Cols; //(Fields.GetLength(0) - insideCommas) may be exceed the Cols
                                        String[] temp = new String[validFildsCount];
                                        int totalOffSet = 0;
                                        for (int iii = 0; iii < validFildsCount - totalOffSet; iii++)
                                        {
                                            bool combine = false;
                                            int storedIndex = 0;
                                            for (int iInLeft = 0; iInLeft < singleLeftquota.Count; iInLeft++)
                                            {
                                                if (iii + totalOffSet == singleLeftquota[iInLeft])
                                                {
                                                    combine = true;
                                                    storedIndex = iInLeft;
                                                    break;
                                                }
                                            }
                                            if (combine)
                                            {
                                                int offset = singleRightquota[storedIndex] - singleLeftquota[storedIndex];
                                                for (int combineI = 0; combineI <= offset; combineI++)
                                                {
                                                    temp[iii] += Fields[iii + totalOffSet + combineI] + ",";
                                                }
                                                temp[iii] = temp[iii].Remove(temp[iii].Length - 1, 1);
                                                totalOffSet += offset;
                                            }
                                            else
                                            {
                                                temp[iii] = Fields[iii + totalOffSet];
                                            }
                                        }
                                        Fields = temp;
                                    }
                                }
                            }
                            Row = dt.NewRow();
                            for (int f = 0; f < Cols; f++)
                            {
                                Fields[f] = Fields[f].Replace("\"\"", "\""); //Two consecutive quotes indicate a user's quote
                                if (Fields[f].StartsWith("\""))
                                {
                                    if (Fields[f].EndsWith("\""))
                                    {
                                        Fields[f] = Fields[f].Remove(0, 1);
                                        if (Fields[f].Length > 0)
                                        {
                                            Fields[f] = Fields[f].Remove(Fields[f].Length - 1, 1);
                                        }
                                    }
                                }
                                Row[f] = Fields[f];
                            }
                            dt.Rows.Add(Row);
                            rowcount++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception( "row: " + (rowcount+2) + ", " + ex.Message);
                }
                //OleDbConnection connection = new OleDbConnection(string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=""text;HDR=Yes;FMT=Delimited"";", FilePath + FileName));
                //OleDbCommand command = new OleDbCommand("SELECT * FROM " + FileName, connection);
                //OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                //DataTable dt = new DataTable();
                //adapter.Fill(dt);
                //adapter.Dispose();
                return dt;
            }
            else
                return null;
            //OleDbConnection connection = new OleDbConnection(string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=""text;HDR=Yes;FMT=Delimited"";", strFilePath));
            //OleDbCommand command = new OleDbCommand("SELECT * FROM " + strFileName, connection);
            //OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //return dt;
        }
