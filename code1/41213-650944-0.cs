    public interface IIntValued
    {
      int Value { get; set; }
    }
    
    public class Record : IIntValued
    {
      public string Value { get; set; }
      int IIntValued.Value
      {
        get
        {
          string value = this.Value;
          return int.Parse(value);
        }
        set { }
      }
    }
