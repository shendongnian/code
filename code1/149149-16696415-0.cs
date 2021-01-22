    using (MyFileDataReader reader = new MyFileDataReader(@"C:\myfile.txt"))
     {
          SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
          bulkCopy.DestinationTableName = "[my_table]";
          bulkCopy.BatchSize = 10000;
          bulkCopy.WriteToServer(reader);
          bulkCopy.Close();
     } 
