    void WriteItemsToFile(IEnumerable<string> list)
    {
       var fileLoc = @"F:\WindowsApplication" + new Guid()+".txt";
                            
       using (var fs = File.Create(fileLoc))
       {
           foreach (var item in list)
           {
              StreamWriter sw = new StreamWriter(fs);
              sw.Write(item);                                     
           }
           jobIdArray.Clear();
           totalCount = 0;
           fs.Close();
       }
    }
