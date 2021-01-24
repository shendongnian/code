        public class ClassA
        {
         public int ID { get; set; }
         public string Countries {get;set;}
         public string Areas{ get;set; }
        }
    
    
    public class ComponentClass
    {
       public List<ClassA> classAObj { get; set; }
       public List<ClassA> classBObj { get; set; }
    }
    
    
    Main()
    {
      ComponentClass[] c = //Data from 3rd party;
      foreach(var data in c)
      {
        Parent p = new Parent(); 
        GetParent   (p ,data.classAObj )
        GetParent   (p ,data.classBObj )
       }
    }
    
    void GetParent (Parent p, ClassA classObj){
     if(data.classAObj.count > 0)
        {
          Star s = new Star();
          s.Area = "infinite";
          s.Color = "red";
          List<string> sep = data.Areas.Split(',').Select(string.Parse).ToList();    
          foreach(var b in sep)
          {
           TinyStar t = new TinyStar();
           t.smallD = b;
           s.Values.Add(t);
           }
          p.Curves.Add(s);
         }
    return p ;
    }
