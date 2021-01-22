    [AttributeUsage(AttributeTargets.Property,
                    Inherited = false,
                    AllowMultiple = false)]
    internal sealed class OptionalAttribute : Attribute
    {
    }
    
    public class Person
    {
        public string Name { get; set; }
    
        [Optional]
        public string NickName { get; set; }
    }
    
    public class Verifier
    {
        public bool IsInputOK(Person person)
        {
            foreach (var property in person.GetType().GetProperties())
            {
                if (property.IsDefined(typeof(OptionalAttribute), true))
                {
                    continue;
                }
                if (string.IsNullOrEmpty((string)property.GetValue(person, null)))
                {
                    return false;
                }
            }
            return true;
        }
    }
