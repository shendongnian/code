    #region SearchForNonDistinctMembersInAGenericListSample
    public static string[] carColors = new[]{"Red", "Blue", "Green"}; 
    public static string[] carStyles = new[]{"Compact", "Sedan", "SUV", "Mini-Van", "Jeep"}; 
    public class Car
    {
        public Car(){}
        public string Color { get; set; }
        public string Style { get; set; }
    }
    public static List<Car> SearchForNonDistinctMembersInAList()
    {
        // pass in cars normally, but declare here for brevity
        var cars = new List<Car>(5) { new Car(){Color=carColors[0], Style=carStyles[0]}, 
                                          new Car(){Color=carColors[1],Style=carStyles[1]},
                                          new Car(){Color=carColors[0],Style=carStyles[2]}, 
                                          new Car(){Color=carColors[2],Style=carStyles[3]}, 
                                          new Car(){Color=carColors[0],Style=carStyles[4]}};
        List<Car> carDupes = new List<Car>();
        for (int i = 0; i < carColors.Length; i++)
        {
            Func<Car,bool> dupeMatcher = c => c.Color == carColors[i];
            int count = cars.Count<Car>(dupeMatcher);
            
            if (count > 1) // we have duplicates
            {
                foreach (Car dupe in cars.Where<Car>(dupeMatcher).Skip<Car>(1))
                {
                    carDupes.Add(dupe);
                }
            }
        }
        return carDupes;
    }
    #endregion
