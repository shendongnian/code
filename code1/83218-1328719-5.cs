    DataSet dsExcelContent = new DataSet();
   
         //Fill from db
            //
             StringBuilder builder = new StringBuilder();
            foreach (DataRow row in dsExcelContent.Tables[0].Rows)
            {
               
                
                builder.Append(row[0].ToString());
                builder.Append(" ");
               
                
            }
            Console.WriteLine(builder.ToString());
