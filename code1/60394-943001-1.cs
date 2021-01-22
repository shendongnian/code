    DataTable dt = new DataTable();
                    dt.Columns.Add("Order", typeof(Int32));
                    dt.Columns.Add("Name");
    
                    for (int iCount =0; iCount< str.Count ; iCount ++)
                    { 
                        DataRow drow1 = dt.NewRow();
                        drow1[0] = iIndex[iCount];
                        drow1[1] = str[iCount];
                        dt.Rows.Add(drow1);
                       
                    }
                    dt.AcceptChanges();
