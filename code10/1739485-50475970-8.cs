    private static void Main()
    {
        var vehicles = new List<Vehicle>
        {
            new Vehicle {Name = "Vehicle", Color = Color.Blue},
            new Truck {Name = "Pickup Truck", Color = Color.Red, CargoCapacity = 12.4},
            new Car {Name = "SUV", Color= Color.Purple, SeatCount = 7}
        };
        foreach (Vehicle vehicle in vehicles)
        {
            Console.Write("This item is a: " + vehicle.Color.Name + " " + vehicle.Name);
            if (vehicle is Truck)
            {
                // It's a truck so create a truck from it and show the truck properties
                Truck truck = vehicle as Truck;
                Console.Write(" with cargo capacity of " + truck.CargoCapacity +
                              " square feet.");
            }
            else if (vehicle is Car)
            {
                // It's a car so create a car from it and show the car properties
                Car car = vehicle as Car;
                Console.Write(" with seating for " + car.SeatCount + " people");
            }
            Console.WriteLine();
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
