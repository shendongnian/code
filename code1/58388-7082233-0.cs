    public Form1()
    {
        InitializeComponent();
        comboBox.DataSource = EnumWithName<SearchType>.ParseEnum();
        comboBox.DisplayMember = "Name";
    }
    public class EnumWithName<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
        public static EnumWithName<T>[] ParseEnum()
        {
            List<EnumWithName<T>> list = new List<EnumWithName<T>>();
            foreach (object o in Enum.GetValues(typeof(T)))
            {
                list.Add(new EnumWithName<T>
                {
                    Name = Enum.GetName(typeof(T), o).Replace('_', ' '),
                    Value = (T)o
                });
            }
            return list.ToArray();
        }
    }
    public enum SearchType
    {
        Value_1,
        Value_2
    }
