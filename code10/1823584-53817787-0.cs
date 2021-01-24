     public class AClass
     {
         public BClass BClass { get; set; }
     }
     public class BClass
     {
         public string name;
         public string id;
     }
----
    public class Program
    {
        public static void Main()
        {
            AClass newitem = new AClass();
            BClass myBClass = newitem.BClass;
        }
    }
