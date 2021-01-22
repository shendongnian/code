    public interface IProperty 
    {
       int price { get; set; }
       float bathrooms { get; set; }
    }
    public class Residential : IProperty
    {
       public int price { get; set; }
       public float bathrooms { get; set; }
       //Other stuff...
    }
    public class Commercial : IProperty
    {
       public int price { get; set; }
       public float bathrooms { get; set; }
       //Other stuff...
    }
