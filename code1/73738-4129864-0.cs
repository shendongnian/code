    public class NameValue
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    
    
        public static List<NameValue> EnumToList<T>()
        {
            var array = (T[])(Enum.GetValues(typeof(T)).Cast<T>()); 
            var array2 = Enum.GetNames(typeof(T)).ToArray<string>(); 
            List<NameValue> lst = null;
            for (int i = 0; i < array.Length; i++)
            {
                if (lst == null)
                    lst = new List<NameValue>();
                string name = array2[i];
                T value = array[i];
                lst.Add(new NameValue { Name = name, Value = value });
            }
            return lst;
        }
