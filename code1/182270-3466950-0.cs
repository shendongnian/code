    public interface C
    {
        int SomeMethodInC();
    }
    
    public class A
    {
    }
    
    public class B : A, C
    {
    }
    
    ... in other class....
    B someB = new B();
    i someInt = someB.SomeMethodInC();
