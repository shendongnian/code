    public class ConstrainedType<T> 
    {
        public Type Type { get; private set; }
        public ConstrainedType (Type type)
        {
            // may have this backward, would have to fact check before
            // rolling out to prod ;)
            if (!typeof (T).IsAssignableFrom (type))
            {
                // throw meaningful exception!
            }
            Type = type;
        }
    }
    List<ConstrainedType<SomeTypeConstraint>> list = 
        new List<ConstrainedType<SomeTypeConstraint>> ();
    // will throw meaningful exception if MyClass is not 
    // SomeTypeConstraint or a sub class
    list.Add (new ConstrainedType (typeof (MyClass)));
    SomeTypeConstraint baseType = 
        (SomeTypeConstraint)(Activator.CreateInstance(list[0].Type));
