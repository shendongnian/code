    public class yourClassName
    {
         public string field { get; set; }
         public string fullname { get; set; }
         public int worker_id { get; set; }
    }
    public class yourMainClass
    {
         public BindingList<yourClassName> yourDataForGrid { get; }
         public yourMainClass(//this is a constructor.  your params go here)
         {
              yourDataForGrid = GetDataForGrid(//your params here)
         }
    }
