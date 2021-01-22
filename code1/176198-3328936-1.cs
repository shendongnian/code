    // all logic goes into this class
    public static class Comparisons
    {
        // note: static, so don't use in multi-threading environments!
        // must use Delegate as type here, Func<XX, string> would not work, as we cannot possibly know what XX is
        // up front. This is not a problem, as Delegate is the parent of all Func<> and Action<>
        static Dictionary<Type, Delegate> methodLookup = new Dictionary<Type, Delegate>();
        private static Func<T, string> EnsureMethod<T>(T obj)
            where T : class, new()
        {
            Type type = obj.GetType();
            if(!methodLookup.ContainsKey(type))
            {
                // The tricky bit. We cannot use GetProperty here, because we later need a method
                // and we cannot use GetMethod, because it cannot find special methods (hidden gettors)
                MemberInfo[] members = type.GetMember("get_T1");
                if(members == null || members.Length > 1)
                    throw new InvalidOperationException("Object must have one 'T1' gettor property");
                MethodInfo property = members[0] as MethodInfo;
                if(property == null)
                    throw new InvalidOperationException("Object must have 'T1' property");
                
                // creating a delegate is the best way to speed up method invocation
                // this type of delegate is called an "open instance delegate", which is like
                // a static delegate with first parameter as the object to invoke on
                Func<T, string> propertyGettor = (Func<T, string>) Delegate.CreateDelegate(typeof(Func<T, string>), null, property);
                methodLookup.Add(type, propertyGettor);
            }
            // must cast here
            return (Func<T, string>)methodLookup[obj.GetType()];
        }
        // I use a generic extension method here. This is frowned upon by some language purists
        // you can always use a utility helper method, which is the alternative
        public static string GetPropertyT1<T>(this T obj)
            where T : class, new()
        {
            // do something with obj1 being null, this is the BCL default
            if (obj == null)
                throw new ArgumentNullException("Extension method object cannot be null for GetT1 method");
            // if the property is not found, an error is raised, so the following is safe:
            // only the first invocation for each type (class) of object is relatively slow
            Func<T, string> delegateObj1 = EnsureMethod(obj);
            
            // this now is lightning fast: it invokes the method on the instance of obj
            return delegateObj1.Invoke(obj);
        }
        // The actual method that does something, it will return all elements in list1
        // that are also found in list2, replace this with whatever logic you need
        public static IList<U> GetDuplicatesFromList1<U, V>(IEnumerable<U> list1, IEnumerable<V> list2)
            where U: class, new()
            where V: class, new()
        {
            var elementsList1InBoth = from x in list1
                                      join y in list2 on x.GetPropertyT1() equals y.GetPropertyT1()
                                      select x;
            return elementsList1InBoth.ToList();
        }
    }
    // your original classes as A and B, with no inheritance chain or other relations
    public class A
    {
        public A(){}
        public A(string value) { this.T1 = value; }
        public string T1 { get; set; }
    }
    public class B
    {
        public B(){}
        public B(string value) { this.T1 = value; }
        public string T1 { get; set; }
        public string Tx { get; set; }
    }
