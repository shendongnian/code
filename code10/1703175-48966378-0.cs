    public class Foo
    {
        public int[,] Property1 { get; }
        public Foo(int[,] property1)
        {
            Property1 = property1;
        }
    }
    
    var myArray = new int[,] { { 1, 2 }, { 3, 4 } };
    var foo = new Foo(myArray);
