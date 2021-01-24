    public class Foo
    {
        public List<Vector3?> VectorPath;
    }
    Foo p = new Foo();
    //...stuff...
    if (p.VectorPath[someIndex].HasValue)
    {
        //Do things.
    }
