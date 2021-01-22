    public sealed class EnumItem<T>
    {
        T value;
        public override string ToString()
        {
            return Display;
        }
        public string Display { get; private set; }
        public T Value { get; set; }
        public EnumItem(T val)
        {
            value = val;
            Type en = val.GetType();
            MemberInfo res = en.GetMember(val.ToString())?.FirstOrDefault();
            DisplayAttribute display = res.GetCustomAttribute<DisplayAttribute>();
            Display = display != null ? String.Format(display.Name, val) : val.ToString();
        }
        public static implicit operator T(EnumItem<T> val)
        {
            return val.Value;
        }
        public static implicit operator EnumItem<T>(T val)
        {
            return new EnumItem<T>(val);
        }
    }
