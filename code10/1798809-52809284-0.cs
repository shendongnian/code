    public class AddInventoryPage : IDataErrorInfo
    {
        public string Name
        {
            get;
            set;
        }       
    
        public string Error
        {
            get { return null; }
        }
    
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName == "Name")
                {
                    if (this.Name == "")
                        result = "Name can not be empty";
                }
                return result;
            }
        }
    }
