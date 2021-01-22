    public class Test
    {
       private string _Foo;
       public string Foo { set { _Foo = value; _Baz="Foo"; } get { return _Foo; }}
       private string _Bar;
       public string Bar { set { _Bar = value; _Baz="Bar"; } get { return _Bar; }}
       private string _Baz;
       public string Baz { set { _Baz = value; } get { return _Baz; }}
    }
