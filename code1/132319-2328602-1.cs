                    //Open and read the file
                    System.IO.FileStream fs = new System.IO.FileStream("myfilename", System.IO.FileMode.Open);
                    System.IO.StreamReader sr = new System.IO.StreamReader(fs);
        
                    string line = "";
                    line = sr.ReadLine();
        
                    string[] colVal;
        
                    try
                    {
                        //clear of previous data
                        //myDataTable.Clear();
        
                        //for each reccord insert it into a row
                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
        
                                colVal = line.Split('\t');
        
                                DataRow dataRow = myDataTable.NewRow();
        
                                //associate values with the columns
                                dataRow["col1"] = colVal[0];        
                                dataRow["col2"] = colVal[1]; 
                                dataRow["col3"] = colVal[2]; 
        
                                //add the row to the table
                                myDataTable.Rows.Add(dataRow);
                        }
        
                        //close the stream
                        sr.Close();
        
                        //binds the dataset tothe grid view.
                        BindingSource bs = new BindingSource();
                        bs.DataSource = myDataSet;
                        bs.DataMember = myDataTable.TableName;
                        myGridView.DataSource = bs;
                    }
