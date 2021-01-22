                    int inc = 0;
                    int j = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        foreach (DataColumn dc in dt.Columns)
                        {
                            empKeys[inc].Append(dc.ColumnName);
                            inc++;
                        }
                        foreach (DataColumn dc in dt.Columns)
                        {
                            empDetails[j].Append(dr[dc]);
                            j++;
                        }
    
    
                        //mapping keys array and values array in hashtable 
    
                        for (int k = 0; k < empKeys.Length; k++)
                        {
                            sendData.Add(empKeys[k].ToString(), empDetails[k].ToString());
                        }
    
                        inc = 0;
                        j = 0;
                    }
                    //sendData.Add("orderNum", order); 
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string output = jss.Serialize(sendData);
                    return output;
                }
