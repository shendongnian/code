    // prototype of your class
    class Obj 
    {
        public Obj() { IsEmpty = true; }
        public bool IsEmpty { get; private set; }
        public Obj Child { get { return new Obj(); } }  // silly, but I needed a working example
    }
    
    // extension method:
    public static class SomeExtentionMethods
    {
        public static T SelfOrDefault<T>(this T elem)
            where T : class, new()     /* must be class, must have ctor */
        {
            return elem ?? new T();
        }
    }
    
    // your code now becomes very easily readable:
    Obj someObj = getYourObjectFromDeserializing();
    // this is it:
    var x = someObj.SelfOrDefault().Child.SelfOrDefault().Child.SelfOrDefault();
    // now test with one if-statement:
    if(x.IsEmpty())
       // something in the chain was empty
    else
       // all's well that ends well :)
