     class DriveableCar : IDriveable
    {
        private Car _car;
        public DriveableCar()
        {
            _car = new Car();
        }
        public void Start()
        {
            _car.Start();
        }        
        public void Accelerate()
        {
            _car.Accelerate();
        }
        public void Shift(Gear gear)
        {
            _car.Shift(gear);
        }
    }
