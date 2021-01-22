    public interface IFinal
    {
        string YourNameA();
        string YourNameB();
    }
    
    public class C : IFinal
    {
        public A A {get; set;}
        public B B {get; set;}
    
        public string YourNameA()
        {
            return this.A.YourName();
        }
    
        public string YourNameB()
        {
            return this.B.YourName();
        }
    }
