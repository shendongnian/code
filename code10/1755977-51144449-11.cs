    public class Production : BaseModel
    {
       public override string Name => "production";
       // Same as:  public override string Name { get { return "production"; } }
       public override string NamePlural => "productions";
       //....
    }
