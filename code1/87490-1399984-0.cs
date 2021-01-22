    [ComVisible]
    public abstract class Base : IA
    {
        public string P1{get{return "somestring";}}
    }   
    
    [ComVisible]
    public class Concrete : Base, IB
    {
       public string P2{get{return "P2somestring";}}
    }
