    public interface IPublicProperties
    {
      int Property1 { get; }
      int Property2 { get; }
    }
    
    internal class Restricted : IPublicProperties
    { 
      public int Property1 { get; set; }
      public int Property2 { get; set; }
    }
