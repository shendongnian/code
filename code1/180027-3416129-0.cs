    public class MyDynamicWrapper<T> : DynamicObject
    {
        public T Wrapped { get; private set; }
        public Action<T> Pre { get; private set; }
        public Action<T> Post { get; private set; }
        public MyDynamicWrapper(T wrapped, Action<T> pre, Action<T> post)
        {
            this.Wrapped = wrapped;
            this.Pre = pre;
            this.Post = post;
        }
        public override bool TryGetMember(
            GetMemberBinder binder, 
            out object result)
        {
            var type = typeof(T);
            var method = type.GetMethod(binder.Name);
            if (method != null)
            {
                Func<object> func = () =>
                {
                    if (Pre != null)
                        Pre(Wrapped);
                    // support for input parameters could be added here
                    var ret = method.Invoke(Wrapped, null);
                    if (Post != null)
                        Post(Wrapped);
                    return ret;
                };
                result = func;
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
    }
    public class MyDynamicWrapper
    {
        public static MyDynamicWrapper<T> Create<T>(
            T toWrap, 
            Action<T> pre = null, 
            Action<T> post = null)
        {
            return new MyDynamicWrapper<T>(toWrap, pre, post);
        }
    }
    public class MyObject
    {
        public void MyMethod()
        {
            Console.WriteLine("Do Something");
        }
    }
    class Program
    {
        static void Main()
        {
            var myobject = new MyObject();
            dynamic mydyn = MyDynamicWrapper.Create(
                                    myobject, 
                                    p => Console.WriteLine("before"), 
                                    p => Console.WriteLine("after"));
            // Note that you have no intellisence... 
            // but you could use the old implmentation before you 
            //   changed to this wrapped version.
            mydyn.MyMethod();
            /* output below
            before
            Do Something
            after
            */
        }
    }
