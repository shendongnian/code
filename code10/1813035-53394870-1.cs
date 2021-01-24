    public class Switch
    {
        public const bool Value = true;
    }
    
    public class A
    {
        private const string Id = "foo" + (Switch.Value ? "Dev" : "");
    }
