    public class SomeObject : AbstractObject
    {
        public string AnotherProperty
        {
            get
            {
                return someProperty ? "Car" : "Plane";
            }
        }
        bool someProperty = false;
        public bool SomeProperty
        {
            get
            {
                return someProperty;
            }
            set
            {
                SetValue(ref someProperty, value, "SomeProperty", "AnotherProperty");
            }
        }
        public SomeObject() : base()
        {
        }
    }
