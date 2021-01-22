    class Wheel
    {
        public void RepairWhell() { }
    }
    class Chassis
    {
        public void RepairChassis() { }
    }
    class Engine
    {
        public void RepairEngine() { }
    }
    class CarWorkshop
    {
        public string Repair(Wheel value)
        {
            value.RepairWhell();
            return "wheel repaired";
        }
        public string Repair(Chassis value)
        {
            value.RepairChassis();
            return "chassis repaired";
        }
        public string Repair(Engine value)
        {
            value.RepairEngine();
            return "engine repaired";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            dynamic carWorkshop = new CarWorkshop();
            var whell = new Wheel();
            var chassis = new Chassis();
            var engine = new Engine();
            Console.WriteLine(carWorkshop.Repair(whell));
            Console.WriteLine(carWorkshop.Repair(chassis));
            Console.WriteLine(carWorkshop.Repair(engine));
            Console.ReadLine();
        }
    }
