    public class PersonModel: IDataErrorInfo
    {
        public string Name { get; set; }
        public string this[string columnName]
        { 
            get 
            {
                var result = string.Empty;
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                            result = "Name is required";
                        break;
                }
            }
        }
    }
