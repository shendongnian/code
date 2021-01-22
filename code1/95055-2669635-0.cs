    public class EnumDescriptionConverter<T>
    {
        public string GetDescription(T en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
    
            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
    
        public T GetValue(string description)
        {
            foreach (T val in Enum.GetValues(typeof(T)))
            {
                string currDescription = GetDescription(val);
                if (currDescription == description)
                {
                    return val;
                }
            }
    
            throw new ArgumentOutOfRangeException("description", "Argument description must match a Description attribute on an enum value of " + typeof(T).FullName);
        }
    }
