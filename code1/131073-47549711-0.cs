    [AttributeUsage(AttributeTargets.Property)]
    public class SomethingCustomAttribute : Attribute
    {
        public StartupArgumentAttribute([CallerMemberName] string propName = null)
        {
            // propName = "MyProperty"
        }
    }
