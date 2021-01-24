    StringBuilder sb = new StringBuilder();
          
          for (int u = 0; u < mydata.Columns.Count; u++)
                {
                for (int i = 0; i < mydata.Rows.Count; i++)
                        {
                            sb.Append(datatable.Rows[i][u].ToString());
                            if (i < datatable.Rows.Count - 1)
                            {
                                sb.Append(';');
                            }     
                        }
                sb.AppendLine(); 
                }
    File.WriteAllText("C:\\Users\\moki\\Downloads\\Output.csv", sb.ToString()); 
