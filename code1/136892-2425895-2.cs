    using (StreamReader sr = File.OpenText(filepath))
    {
         string line;
         while ((line = sr.ReadLine()) != null)
         {
              // Do something with line...
              lineCount++;
         }
    }
