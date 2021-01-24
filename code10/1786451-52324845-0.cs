    private static void Main(string[] cmdArgs)
    {
        AutoPart motorCraftOilFilter = new AutoPart();
        motorCraftOilFilter.Name = "MotorCraft Oil Filter";
        motorCraftOilFilter.Cost = 6.99;
        Liquid valvolineOil = new Liquid();
        valvolineOil.Name = "Valvoline Oil";
        valvolineOil.Cost = 8.99;
        valvolineOil.Quarts = 1;
        Tool wrench = new Tool();
        wrench.Name = "Duralast 13mm Wrench";
        wrench.Cost = 16.99;
        wrench.SizeInMM = 13;
        var catalog = new List<AutoPart>
        {
            motorCraftOilFilter,
            valvolineOil,
            wrench
        };
        // Pretent the command to order products was entered
        // You can use OrderByDescending to order the items by 
        // Cost from Highest to Lowest
        catalog = catalog.OrderByDescending(part => part.Cost).ToList();
        // Output results
        catalog.ForEach(item => Console.WriteLine(item.Name + " " + item.Cost));
        Console.Write("\nPress any key to exit...");
        Console.ReadKey();
    }
