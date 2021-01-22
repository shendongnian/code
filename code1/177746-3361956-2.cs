    public class ClassWithMethod
    {
        public static List<ICommon> DoSomethingSimple(List<ICommon> myTypes)
        {
            return myTypes.Where(myType => myType.SomeProperty.Equals(2)).ToList();
        }
    }
