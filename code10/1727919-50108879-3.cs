    var summary = xml.LoadFromXml<SalesSummary>();
    // Prints:
    // MealPeriod1 name: "Lunch"
    Console.WriteLine("MealPeriod1 name: \"{0}\"", summary.MealPeriod1.MealPeriodName());
    // Prints 
    // MealPeriod1 Total Sales: "$6,447.58"
    Console.WriteLine("MealPeriod1 Total Sales: \"{0}\"", summary.MealPeriod1.MealPeriodItems<Totals>().Single().Sales);   
