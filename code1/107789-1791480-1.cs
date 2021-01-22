    public interface IBasicProps
    {
       int Priority { get; }
       string Name {get;}
       //... whatever
    }
    
    public interface IBasicPropsWriteable
    {
       int Priority { get; set; }
       string Name { get; set; }
       //... whatever
    }
    
    public class Foo : IBasicProps, IBasicPropsWriteable
    {
       public int Priority { get; set; }
       public string Name { get; set; }
    
       // whatever
    }
