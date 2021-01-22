    private void Form1_Load(object sender, EventArgs e)
    {
        var mc = new MyClass();
        mc.Foo();
        ((MyBaseClass) mc).Foo();
    }
    public class MyBaseClass
    {			
        public virtual void Foo ()
        {
            Console.WriteLine("Calling from MyBaseClass");
        }
    }
    public class MyClass : MyBaseClass
    {
			
        new public void Foo ()
        {
            Console.WriteLine("Calling from MyClass");
        }
    }
