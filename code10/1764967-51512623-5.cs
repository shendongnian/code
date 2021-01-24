    class DriveableBike : IDriveable
    {
        private Bike _bike;
        public DriveableBike()
        {
            _bike = new Bike();
        }
        public void Start()
        {
            _bike.Start();
        }
        public void Shift(Gear gear)
        {
            _bike.Shift(gear);
        }
        public void Accelerate()
        {
            _bike.Accelerate();
        }
    }
