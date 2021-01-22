    public class Furniture
    {
        public virtual int MyProperty {get;}
    }
    public class HomeFurniture : Furniture
    {
        public override int MyProperty
        {
            get
            {
                return 9;
            }
        }
    }
    public class OfficeFurniture : Furniture
    {
        public override int MyProperty
        {
            get
            {
                return 10;
            }
        }
    }
