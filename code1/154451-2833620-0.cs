        public class Car
        {
            public int TopSpeed { get; set; }
            public Car(Car car)
            {
                TopSpeed = car.TopSpeed;
            }
            public Car()
            {
                TopSpeed = 100;
            }
        }
        public class SportsCar : Car
        {
            public string GirlFriend { get; set; }
        }
