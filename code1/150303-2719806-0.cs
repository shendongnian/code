    public class FuelConsumption {
        private double fuel;
        public double Fuel
        {
            get { return this.fuel; }
        }
        public void FillFuelTank(double amount)
        {
            this.fuel += amount;
        }
    }
    
    public static void Main()
    {
        FuelConsumption f = new FuelConsumption();
    
        double a;
        a = f.Fuel; // Will work
        f.Fuel = a; // Does not compile
        f.FillFuelTank(10); // Value is changed from the method's code
    }
