    public class Bar
    {
        public void Foo(int x)
        {
            Console.WriteLine("int");
        }
        public void Foo(string x)
        {
            Console.WriteLine("string");
        }
        public void Foo(object x)
        {
            Console.WriteLine("dunno");
        }
        public void DynamicFoo(object x)
        {
            ((dynamic)this).Foo(x);
        }
    }
    object a = 5;
    object b = "hi";
    object c = 2.1;
    Bar bar = new Bar();
    bar.DynamicFoo(a);
    bar.DynamicFoo(b);
    bar.DynamicFoo(c);
