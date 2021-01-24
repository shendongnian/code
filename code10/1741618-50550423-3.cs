    public class MyGCCollectClass
    {
       public List<Version> Garbage { get; set; }
    
       public List<int> MyInnocentList { get; set; }
    
       public List<int> Main()
       {
          Garbage = new List<Version>();
          for (var i = 0; i < 10000000; i++)
          {
             Garbage.Add(new Version());
          }
    
          MyInnocentList = new List<int>();
          return MyInnocentList;
       }
    }
