    foreach (DataRow dr in d_table.Rows)
    {
       StringBuilder builder = new StringBuilder();
       for (int ir = 0; ir < 3; ir++)
       {
           if (!Convert.IsDBNull(dr[ir]))
           {
              builder.Append(dr[ir].ToString());
           }
           builder.Append(FileDelimiter);       
       }
       
       var lineStart = builder.ToString();
       for (int ir = 3; ir < 6; ir++)
       {
           if (!Convert.IsDBNull(dr[ir]))
           {
    
              sw.Write(lineStart);   
              sw.Write(dr[ir].ToString());
              sw.Write(sw.NewLine);
           }
        
       }
       
       
    }
