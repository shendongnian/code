    using System.IO;
    
    using(StreamWriter sw = File.CreateText("list.csv"))
    {
      for(int i = 0; i < l.Count; i++)
      {
        sw.WriteLine(l[i]);
      }
    }
