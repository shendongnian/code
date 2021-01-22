    public class SomeClass    
    {
        CreateInstanceOfSomethingElse() { return new SomethingElse(this); }
    }
    public static void dostuff<T, U> (List<T> items) where T : SomeClass, U : SomethingElse
    {
        foreach (T item in items)
        {
            func(item.CreateInstanceOfSomethingElse().SpecialMember);
        }
    }
