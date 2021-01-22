    public class ClassWithMethod
    {
        public static List<ICommon> DoSomethingSimple(IEnumerable<ICommon> myTypes)
        {
            return myTypes.Where(myType => myType.SomeProperty.Equals(2)).ToList();
        }
    }
