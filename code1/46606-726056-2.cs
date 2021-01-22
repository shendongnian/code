    // A custom attribute.
    public sealed class VehicleDescriptionAttribute : System.Attribute
    {
        private string msgData;
        public VehicleDescriptionAttribute(string description)
        {
            msgData = description;
        }
        public VehicleDescriptionAttribute() { }
        public string Description
        {
            get { return msgData; }
            set { msgData = value; }
        }
    }
