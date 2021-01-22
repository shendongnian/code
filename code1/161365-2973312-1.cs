    public static class EnumHelper
    {
        public static string GetDescription<T>(T value)
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("value must be Enum.", "value");
            }
    
            var name = value.ToString();
    
            string resourceKey = string.Format(CultureInfo.InvariantCulture, "{0}_{1}", typeof(T).FullName, name);
    
            object resource = HttpContext.GetGlobalResourceObject("EnumDescriptions", resourceKey, Thread.CurrentThread.CurrentUICulture);
            string description = resource as string ?? name;
            return description;
        }
    }
