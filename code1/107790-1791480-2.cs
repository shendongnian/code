    public interface IBasicPropsAll : IBasicProps, IBasicPropsWriteable  { }
    public class Foo : IBasicPropsAll
    {
       public int Priority { get; set; }
       public string Name { get; set; }
    
       // whatever
    }
