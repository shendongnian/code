       public static void ConstructSchema(FileInfo theFile)
        {
            StringBuilder schema = new StringBuilder(); 
            DataTable data = LoadCSV(theFile); 
            schema.AppendLine("[" + theFile.Name + "]");
            schema.AppendLine("ColNameHeader=True"); 
            for (int i = 0; i < data.Columns.Count; i++)
            {
                schema.AppendLine("col" + (i + 1).ToString() + "=" + data.Columns[i].ColumnName + " Text");
            }   
            string schemaFileName = theFile.DirectoryName + @"\Schema.ini";
            TextWriter tw = new StreamWriter(schemaFileName);   
            tw.WriteLine(schema.ToString());
            tw.Close();  
        }
