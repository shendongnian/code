    public class TestPropertyCheck
    {
        public event EventHandler AllPropertiesSet;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                CheckAllProperties(PropertyNames.Id);
            }
        }
        private int _id;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                CheckAllProperties(PropertyNames.Name);
            }
        }
        private string _name;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                CheckAllProperties(PropertyNames.Address);
            }
        }
        private string _address;
        private void CheckAllProperties(PropertyNames propName)
        {
            propertiesSet |= propName;
            if (propertiesSet == PropertyNames.AllProps)
            {
                AllPropertiesSet?.Invoke(this, new EventArgs());
            }
        }
        private PropertyNames propertiesSet = PropertyNames.None;
        [Flags]
        private enum PropertyNames
        {
            None = 0,
            Id = 0x01,
            Name = 0x02,
            Address = 0x04,
            AllProps = Id | Name | Address,
        }
    }
