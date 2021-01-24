    void Main()
    {
       var var = Expression.Variable(typeof(Foo), "foo");
		
       var expr = Expression.Lambda(
        Expression.Lambda(
            Expression.Call(var, typeof(Foo).GetMethod("Bar"))), new[] {  var });
        var res = (Action)expr.Compile().DynamicInvoke(new Foo());
        res();
    }
    class Foo
    {
        public void Bar()
        {
            Console.WriteLine("Bar");
        }
    }
