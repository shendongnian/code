    public class Metadata
    {
       public Type type { get; set; }
       public string Name { set; get; }
    }
    
    public class MetaDataCollection
    {
       public void DoSomeThing()
       {
          List<Metadata> metadataObjects = new List<Metadata>
          {
             new Metadata() { Name = "Name 1", type = typeof(int)},
             new Metadata() { Name = "Name 2", type = typeof(bool)},
             new Metadata() { Name = "Name 3", type = typeof(double)},
          };
    
          foreach (Metadata item in metadataObjects)
          {
             item.Name..
          }
       }
    }
