    DataSet dsExcelContent = new DataSet();
   
         //Fill from db
            //
            
            foreach (DataRow row in dsExcelContent.Tables[0].Rows)
            {
                StringBuilder builder = new StringBuilder();
                
                builder.Append(row[0].ToString());
                builder.Append(" ");
               
                
            }
            Console.WriteLine(builder.ToString());
