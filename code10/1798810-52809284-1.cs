    public class AddInventoryPage : IDataErrorInfo
    {
        public string Name { get; set; }       
    
        public string Error => null;
    
        public string this[string columnName]
        {
            get
            {
                switch(columnName)
                {
                    case nameof(Name):
                        if (Name == string.Empty) return "Name can not be empty";
                }
                return string.Empty;
            }
        }
    }
