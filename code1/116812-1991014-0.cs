    using (StreamReader streamReader = File.OpenText(path))
    {
         while (true)
         {
             string line = streamReader.ReadLine();
             if (line == null)
             {
                 break;
             }
             // Do something with line...
         }
    }
