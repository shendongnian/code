    public class ThingBase
    {
       protected abstract string TableName { get; }
       public int ID { get; set; }
       public string Description { get; set; }
       ...
    }
    public class Thing : ThingBase 
    {
       protected override string TableName { get { return "Thing"; } }
    }
    public class OtherThing : ThingBase
    {
       protected override string TableName: { get { return "OtherThing"; } }
    }
