    static void Main(string[] args)
    {
        var obj = new Foo<object>();
        var obj2 = new Foo<string>();
    }
   
    public class Foo<T>
    {
        static Foo()
        {
             System.Diagnostics.Debug.WriteLine(String.Format("Hit {0}", typeof(T).ToString()));        }
    }
