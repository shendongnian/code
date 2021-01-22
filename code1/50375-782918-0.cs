    abstract class Car
    {
        private CarWheel wheel;
        public CarWheel Wheel
        {
            get { return wheel; }
            protected set { wheel = value; }
        }
    }
    class FastCar : Car
    {
        public new FastCarWheel Wheel
        {
            get { return base.Wheel as FastCarWheel; }
            set { base.Wheel = value; }
        }
    }
    class SlowCar : Car
    {
        public new SlowCarWheel Wheel
        {
            get { return base.Wheel as SlowCarWheel ; }
            set { base.Wheel = value; }
        }
    }
