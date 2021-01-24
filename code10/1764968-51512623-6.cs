    class Program
    {
        private static void Main(string[] args)
        {
            // USING THE CAR
            var car = new DriveableCar();
            car.Start();
            car.Shift(Gear.Drive);
            car.Accelerate();
            //USING THE BIKE
            var bike = new DriveableBike();
            bike.Start();
            bike.Shift(Gear.Drive);
            bike.Accelerate();
            Console.Read();
        }
    }
