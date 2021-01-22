        public abstract class Car
        {
            public abstract WheelPart Wheel { get; }
        }
    
        public class FastCar : Car
        {
            private FastWheel _wheel;
            public override WheelPart Wheel
            {
                get { return _wheel; }
            }
    
            public void SetWheel(FastWheel wheel)
            {
                _wheel = wheel;
            }
        }
