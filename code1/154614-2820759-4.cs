RemoteMgr.ExposeProperty(() => SomeClass.SomeProperty)
    public class SomeClass
    {
        public static string SomeProperty
        {
            get { return "Foo"; }
        }
    }
    public class RemoteMgr
    {
        public static void ExposeProperty<T>(Expression<Func<T>> property)
        {
            var expression = GetMemberInfo(property);
            string path = string.Concat(expression.Member.DeclaringType.FullName,
                ".", expression.Member.Name);
            // Do ExposeProperty work here...
        }
    }
    public class Program
    {
        public static void Main()
        {
            RemoteMgr.ExposeProperty("SomeSecret", () => SomeClass.SomeProperty);
        }
    }
