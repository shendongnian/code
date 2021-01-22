    private class Adapter<T>
    {
        private readonly Action<object> act;
        
        public Adapter(Action<object> act){
            this.act = act;
        }
        public void Do(T o)
        {
            act(o);
        }
    }
    public static void Main(string[] args)
    {
        Type elementType = typeof(string);
	
        var genericType = typeof(List<>).MakeGenericType(elementType);
        var list = Activator.CreateInstance(genericType);
        var addMethod = list.GetType().GetMethod("Add");
        addMethod.Invoke(list, new object[] { "foo" });
        addMethod.Invoke(list, new object[] { "bar" });
        addMethod.Invoke(list, new object[] { "what" });
        Action<object> printDelegate = o => Console.WriteLine(o);
        var adapter = Activator.CreateInstance(typeof(Adapter<>).MakeGenericType(elementType), printDelegate);
        var adapterDo = adapter.GetType().GetMethod("Do");
        var adapterDelegate = Delegate.CreateDelegate(typeof(Action<string>), adapter, adapterDo);
        var foreachMethod = list.GetType().GetMethod("ForEach");
        foreachMethod.Invoke(list, new object[] { adapterDelegate });
    }
