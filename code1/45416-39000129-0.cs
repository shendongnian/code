    public class Truck
    {
        private string _Name = "Super truck";
        private int _Tires = 4;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public int Tires
        {
            get { return _Tires; }
            set { _Tires = value; }
        }
        private Truck SavePoint;
        public static Truck CreateWithSavePoint(string Name, int Tires)
        {
            Truck obj = new Truck();
            obj.Name = Name;
            obj.Tires = Tires;
            obj.Save();
            return obj;
        }
        public Truck() { }
        public void Save()
        {
            SavePoint = (Truck)this.MemberwiseClone();
        }
        public void ResetTruck()
        {
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Count(); ++i)
                properties[i].SetValue(this, properties[i].GetValue(SavePoint));
        }
    }
