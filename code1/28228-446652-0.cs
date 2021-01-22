    public class DataItem
    {
      string Title {get;set;}
      object Value {get;set;}
    }
    
    public interface IDataItems
    {
      IEnumerable<DataItem> Items()
    }
    
    
    //suppose LINQ gives you this:
    public partial class Customer
    {
      public string Name {get;set;}
      public string Address {get;set;}
      public int Age {get;set;}
    }
    
    //then you add this in another file.
    //if there's a lot of this, it can be code genned by design-time reflection
    public partial class Customer : IDataItems
    {
      public IEnumerable<DataItem> IDataItems.Items()
      {
        yield return new DataItem() {"Name", Name};
        yield return new DataItem() {"Address", Address};
        yield return new DataItem() {"Age", Age};
      }
    }
    
    //and the foreach loops look like this:
    foreach(DataItem d in ViewData.OfType<IDataItems>().First().Items())
    {
      d.Title;
    }
    foreach(IDataItems container in ViewData.OfType<IDataItems>())
    {
        foreach(DataItem d in container.Items())
        {
           d.Value;
        }
    }
