        public enum EngineType
        {
            Diesel,
            Gasoline
        }
        public class Bicycle
        {
            public int Cylinders;
        }
        public class Car
        {
            public EngineType EngineType;
            public int Doors;
        }
        public class MotorCycle
        {
            public int Cylinders;
        }
        public void Run()
        {
            var getRentPrice = new PatternMatcher<int>()
                .Case<MotorCycle>(bike => 100 + bike.Cylinders * 10) 
                .Case<Bicycle>(30) 
                .Case<Car>(car => car.EngineType == EngineType.Diesel, car => 220 + car.Doors * 20)
                .Case<Car>(car => car.EngineType == EngineType.Gasoline, car => 200 + car.Doors * 20)
                .Default(0);
            var vehicles = new object[] {
                new Car { EngineType = EngineType.Diesel, Doors = 2 },
                new Car { EngineType = EngineType.Diesel, Doors = 4 },
                new Car { EngineType = EngineType.Gasoline, Doors = 3 },
                new Car { EngineType = EngineType.Gasoline, Doors = 5 },
                new Bicycle(),
                new MotorCycle { Cylinders = 2 },
                new MotorCycle { Cylinders = 3 },
            };
            foreach (var v in vehicles)
            {
                Console.WriteLine("Vehicle of type {0} costs {1} to rent", v.GetType(), getRentPrice.Match(v));
            }
        }
