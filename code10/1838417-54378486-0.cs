    // Dummy class representing an element in the structure
    public class A : Strcuture { }
    // Dummy class representing an element in the structure
    public class B : Strcuture { }
    // Dummy class representing an element in the structure
    public class C : Strcuture { }
    
    // Base Dummy class for Base Structure elements
    public abstract class Strcuture {
        public List<Strcuture> Elements { get; } = new List<Strcuture>();
        public void AddElement(Strcuture element) {
            Elements.Add(element);
        }
        public void RecursiveMethod(HashSet<object> recursiveChecker) {
            if(recursiveChecker == null){
                recursiveChecker = new HashSet<object>();
            }
            var addedThis = recursiveChecker.Add(this);
            if(addedThis == false) {
                // this object has already been handled
                // throw exception?? return early etc
                throw new System.Exception("Already handled object");
            }
            foreach (var elem in Elements) {
                elem.RecursiveMethod(recursiveChecker);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new B();
            var c = new C();
            a.AddElement(b);
            b.AddElement(c);
            c.AddElement(a);
            // now our object structure contains a loop
            // A→B→C→A→B...
            a.RecursiveMethod(new HashSet<object>());
        }
    }
