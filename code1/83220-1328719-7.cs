            foreach (DataRow row in dsExcelContent.Tables[0].Rows)
            {
               
                builder.Append(row[0].ToString());
                builder.Append(" ");
    
    
            }
                //s has the data you want.....
            string s = builder.ToString();
    
                //REST OF YOUR CODE.....
