    public static string DataTableToJSON(DataTable Dt)
                {
                    string[] StrDc = new string[Dt.Columns.Count];
        
                    string HeadStr = string.Empty;
                    for (int i = 0; i < Dt.Columns.Count; i++)
                    {
        
                        StrDc[i] = Dt.Columns[i].Caption;
                        HeadStr += "\"" + StrDc[i] + "\":\"" + StrDc[i] + i.ToString() + "¾" + "\",";
        
                    }
        
                    HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);
        
                    StringBuilder Sb = new StringBuilder();
        
                    Sb.Append("[");
        
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
        
                        string TempStr = HeadStr;
        
                        for (int j = 0; j < Dt.Columns.Count; j++)
                        {
        
                            TempStr = TempStr.Replace(Dt.Columns[j] + j.ToString() + "¾", Dt.Rows[i][j].ToString().Trim());
                        }
                        //Sb.AppendFormat("{{{0}}},",TempStr);
        
                        Sb.Append("{"+TempStr + "},");
                    }
        
                    Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));
        
                    if(Sb.ToString().Length>0)
                    Sb.Append("]");
        
                    return StripControlChars(Sb.ToString());
        
                } 
     //Function to strip control characters:
    
    //A character that does not represent a printable character  but serves to initiate a particular action.
        
                public static string StripControlChars(string s)
                {
                    return Regex.Replace(s, @"[^\x20-\x7F]", "");
                }
