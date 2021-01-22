    public class ConcreteClass : AbstractClass
    {
        public override MyProperty {
           get
           {
                return _someValue;
           }
           set
           {
                if( _someValue != value ) _someValue = value;
           }
    }
