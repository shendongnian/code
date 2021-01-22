    public class Referall
    {
       // these should be named in line with what they represent...
       public string FirstString   { get; set; }
       public string AnotherString { get; set; }
       public int    SomeValue     { get; set; }
    
       public Referall( string first, string another, int value )
       {
           FirstString = first;
           AnotherString = another;
           SomeValue = value;
       }
    }
