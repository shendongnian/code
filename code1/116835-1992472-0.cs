    [AttributeUsage(AttributeTargets.Field)]
    class PassDownAttribute : Attribute
    {
    }
    public class TheParent
    {
        [PassDown]
        public int field1;
        [PassDown]
        public string field2;
        [PassDown]
        public double field3;
        public int field4; // Won't pass down.
        public TheChild CreateChild()
        {
            TheChild x = new TheChild();
            var fields = typeof(TheParent).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach (var field in fields)
            {
                var attributes = field.GetCustomAttributes(typeof(PassDownAttribute), true);
                if (attributes.Length == 0) continue;
                var sourceValue = field.GetValue(this);
                var targetField = typeof(TheChild).GetField(field.Name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (targetField != null)
                    targetField.SetValue(x, sourceValue);
            }
            return x;
        }
    }
    public class TheChild
    {
        public int field1;
        public string field2;
        public double field3;
    }
