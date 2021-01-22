    public static class DescriptionDictionary<T> where T : struct
    {
        private static readonly Dictionary<string, T> Map = 
            new Dictionary<string, T>();
        static DescriptionDictionary()
        {
            if (typeof(T).BaseType != typeof(Enum))
            {
                throw new ArgumentException("Must only use with enums");
            }
            // Could do this with a LINQ query, admittedly...
            foreach (var field in typeof(T).GetFields
                     (BindingFlags.Public | BindingFlags.Static))
            {
                T value = (T) field.GetValue(null);
                foreach (var description in (DescriptionAttribute[]) 
                   field.GetCustomAttributes(typeof(DescriptionAttribute), false))
                {
                    // TODO: Decide what to do if a description comes up
                    // more than once
                    Map[description.Description] = value;
                }
            }
        }
        public static T GetValue(string description)
        {
            T ret;
            if (Map.TryGetValue(description, out ret))
            {
                return ret;
            }
            throw new WhateverException("Description not found");
        }
    }
