    //This represents the contract, regardless of the underlying object
    public interface ISomeObject
    {
    }
    //Class is internal, but implements the interface
    internal class A : ISomeObject { }
    internal abstract class B : A { }
    internal abstract class C : B { }
    //Class D is still internal
    internal class D : C { }
    public class E
    {   
        //Method uses interface, which is public     
        public void X(ISomeObject c) { }
        public ISomeObject DoSomething()
        {
            //Create internal class, return it for use (as a contract)
            return new D();
        }
    }
