    public struct MyPoint
    {
        public readonly double x, y;
        public MyPoint(double x, double y) { this.x=x; this.y=y; }
        // User types must have defined operators
        public static MyPoint operator+(MyPoint a, MyPoint b)
        {
            return new MyPoint(a.x+b.x, a.y+b.y);
        }
    }
    class Program
    {
        // Sample generic method using Operation<T>
        public static T DoubleIt<T>(T a)
        {
            Func<T, T, T> add=Operation<T>.Add;
            return add(a, a);
        }
        // Example of using generic math
        static void Main(string[] args)
        {
            var x=DoubleIt(1);              //add integers, x=2
            var y=DoubleIt(Math.PI);        //add doubles, y=6.2831853071795862
            MyPoint P=new MyPoint(x, y);
            var Q=DoubleIt(P);              //add user types, Q=(4.0,12.566370614359172)
            var s=DoubleIt("ABC");          //concatenate strings, s="ABCABC"
        }
    }
    
