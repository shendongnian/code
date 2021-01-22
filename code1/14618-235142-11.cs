    public class CustomerInfo
    {
        public string Name
        {
            get
            {
                return SessionVar.GetString("CustomerInfo_Name");
            }
            set
            {
                SessionVar.SetString("CustomerInfo_Name", value);
            }
        }
    }
