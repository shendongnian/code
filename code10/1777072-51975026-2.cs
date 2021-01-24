    static class Copy
    {
        public static void ObjectToAnother<T>(T source, T target)
        {
            foreach (var sourceProp in source.GetType().GetProperties())
            {
                var targetProp = target.GetType().GetProperty(sourceProp.Name);
                targetProp.SetValue(target, sourceProp.GetValue(source, null), null);
            }
        }
    }
