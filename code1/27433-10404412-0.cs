    public partial class LocationView : Location
    {
        public LocationView() {}
        // base class copy constructor
        public LocationView(Location value) {
            Type t = typeof(Location);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(value, null), null);
            }
        }
        public Quote Quote { get; set; }
    }
