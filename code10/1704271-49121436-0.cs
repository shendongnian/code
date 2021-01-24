     public class DataGridColumnDef : NotifyPropertyChangeModel
        {
            public string Name
            {
                get => _Name;
                set => SetValue(ref _Name, value);
            }
            private string _Name;
    
            public Type DataType
            {
                get => _DataType;
                set => SetValue(ref _DataType, value);
            }
            private Type _DataType;
    
            public DataGridColumnDef(string name, Type type)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
                DataType = type ?? throw new ArgumentNullException(nameof(type));
            }
        }
