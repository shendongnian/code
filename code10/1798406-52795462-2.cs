    [AttributeUsage(AttributeTargets.Property)]
    public class NotNullAttribute : Attribute
    {
        public bool IsValid(object value)
        {
            if (!string.IsNullOrEmpty(value as string))
            {
                return false;
            }
            return true;
        }
    }
