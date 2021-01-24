    string line;
    bool bheader= false;
                        //reader.ReadLine(); //skip first line
                        while (reader.Peek() != -1)
                        {
    
                            line = reader.ReadLine();
                            if (line == null || line.Length == 0)
                                continue;
    
                            string[] values = line.Split('|').Skip(1).ToArray();
    
     
                            if (!isColumnCreated)
                            {
    
                                for (int i = 0; i < values.Count(); i++)
                                {
                                    table.Columns.Add(values[i]);
                                }
                                isColumnCreated = true;
    							bheader = true;
                            }
    if(bheader ==false){
                            DataRow row = table.NewRow();
    
                            for (int i = 0; i < values.Count(); i++)
                            {
                                row[i] = values[i];
    
                            }
                            table.Rows.Add(row);
                            products++;
                        }
    					}
    					bheader = false;
                    }
