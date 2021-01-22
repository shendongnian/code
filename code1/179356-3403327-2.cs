        class Program
        {
            static void Main(string[] args)
            {
                var engine = Python.CreateEngine();
                var scriptScope = engine.CreateScope();
                var foo = new Foo(engine);
                scriptScope.SetVariable("Foo", foo);
                const string script = @"
    class MyClass(object):
        def __init__(self):
            print ""this should be called""
    Foo.Create(MyClass)
    ";
                var v = engine.Execute(script, scriptScope);
            }
        }
    public  class Foo
    {
        private readonly ScriptEngine engine;
        public Foo(ScriptEngine engine)
        {
            this.engine = engine;
        }
        public  object Create(object t)
        {
            return engine.Operations.CreateInstance(t);
        }
    }
