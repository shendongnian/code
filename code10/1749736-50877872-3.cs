    class Container
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        [IsNumber]
        string ContactNo { get; set; }
    }
    public class IsNumber : Attribute { }
    public static void test()
        {
            var flags = BindingFlags.Public |
                       BindingFlags.NonPublic |
                       BindingFlags.Instance |
                       BindingFlags.Static;
            foreach (PropertyInfo property in typeof(Container).GetProperties(flags))
            {
                if (property.GetCustomAttributes(typeof(IsNumber), true).Length > 0)
                {
                    MessageBox.Show("property " + property.Name + " is number");
                    // this is a number field
                }
                // Check custom identifier to see whether a random word or number is required.
            }
        }
