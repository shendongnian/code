    class Container
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        [IsNumber]
        string ContactNo { get; set; }
    }
    public class IsNumber : Attribute { }
    public void test()
    {
        var flags = BindingFlags.Public |
                   BindingFlags.NonPublic |
                   BindingFlags.Instance |
                   BindingFlags.Static;
        foreach (FieldInfo field in typeof(Container).GetFields(flags))
        {
            if (field.GetCustomAttributes(typeof(IsNumber), true).Length > 0)
            {
                // this is a number field
            }
            // Check custom identifier to see whether a random word or number is required.
        }
    }
