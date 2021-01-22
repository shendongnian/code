    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            IVehicle contract = (IVehicle)car;
            UseContract(contract);  // This line is identical...
            Airplane airplane = new Airplane();
            contract = (IVehicle)airplane;
            UseContract(contract);  // ...to the line above!
        }
        private static void UseContract(IVehicle contract)
        {
            // Try typing these 3 lines yourself, watch IDE behavior.
            contract.Drive();
            contract.Steer();
            contract.UseHook();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
