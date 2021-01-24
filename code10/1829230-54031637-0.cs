    List<List<string>> mylist = new List<List<string>>();
    using (StreamReader sr = new StreamReader(File.OpenRead("Smart Eye data.csv")))
    {
       string line;
       while((line = sr.ReadLine()) != null)  
       {  
          System.Console.WriteLine(line);  
          List<string>row = line.Split(",").ToList();
          mylist.Add(row);
       }
    }
    ...
 
