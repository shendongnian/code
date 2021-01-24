    public class FilterViewModel
    {
        private string _vehicleEntity;
        public string VehicleEntity
        {
            get { return _vehicleEntity; }
            set
            {
                _vehicleEntity = value;
                //OnPropertyChanged() if you want
            }
        }
        private string _attribute;
        public string Attribute
        {
            get { return _attribute; }
            set
            {
                _attribute = value;
                //Add logic here to determine what to do with both Attribute and VehicleEntity
                //OnPropertyChanged() if you want
            }
        }
    }
