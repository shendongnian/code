    // prototype of your class
    class Obj 
    {
        public Obj() { IsEmpty = true; }
        public bool IsEmpty { get; private set; }
        public Obj Child { get { return new Obj(); } }  // silly, but I needed a working example
    }
    
    // extension method:
    public static class NullTesters
    {
        public static T NotNull<T>(this T elem)
            where T : class, new()
        {
            return elem ?? new T();
        }
    }
    
    // your code now becomes very easily readable:
    Obj someObj = getYourObjectFromDeserializing();
    // this is it:
    var x = someObj.NotNull().Child.NotNull().Child.NotNull();
    // now test with one if-statement:
    if(x.IsEmpty())
       // something in the chain was not empty
    else
       // all's well that ends well :)
