    class Program
    {
        static void Main()
        {
            dynamic x = new ExpandoObject();
            x.Name = "Damian Powell";
            x.Age = "21 (probably)";
            if (Dynamic.HasMember(x, "Age"))
            {
                Console.WriteLine("Age={0}", x.Age);
            }
        }
    }
    public static class Dynamic
    {
        public static bool HasMember(object dynObj, string memberName)
        {
            return GetMemberNames(dynObj).Contains(memberName);
        }
        public static IEnumerable<string> GetMemberNames(object dynObj)
        {
            var metaObjProvider = dynObj as IDynamicMetaObjectProvider;
            if (null == metaObjProvider) throw new InvalidOperationException(
                "The supplied object must be a dynamic object " +
                "(i.e. it must implement IDynamicMetaObjectProvider)"
            );
            var metaObj = metaObjProvider.GetMetaObject(
                Expression.Constant(metaObjProvider)
            );
            var memberNames = metaObj.GetDynamicMemberNames();
            return memberNames;
        }
    }
