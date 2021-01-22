    class CarFactory
    {
        public Car BuildCar()
        {
            return new Car(BuildDoor);
        }
        public CarDoor BuildDoor(Car car)
        {
            return new CarDoor(car);
        }
    }
    class Car
    {
        private List<CarDoor> _carDoors = new List<CarDoor>();
        public Car(Func<Car, CarDoor> buildDoor)
        {
            for (int i=0; i<4; i++)
                _carDoors.Add(buildDoor(this));
        }
    }
    class CarDoor
    {
        private Car _associatedCar;
        public CarDoor(Car associatedCar)
        {
            _associatedCar = associatedCar;
        }
    }
