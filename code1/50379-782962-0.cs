        public abstract class Car
        {
            public abstract WheelPart Wheel { get; set; }
        }
    
        public class FastCar : Car
        {
            private FastWheel _wheel;
            public override WheelPart Wheel
            {
                get { return _wheel; }
                set
                {
                    if (!(value is FastWheel))
                    {
                        throw new ArgumentException("Supplied wheel must be Fast");
                    }
                    _wheel = (FastWheel)value;
                }
            }
        }
