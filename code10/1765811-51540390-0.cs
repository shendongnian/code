    public static void CarTest()
    {
        var origList = new List<Car>();
        origList.Add(new Car() { Name = "A"});
        origList.Add(new Car() { Name = "B" });
        origList.Add(new Car() { Name = "C" });
        origList.Add(new Car() { Name = "D" });
        origList.Add(new Car() { Name = "E" });
        var afterList = origList.Where(c => c.Name != "A");
        var missingList = origList.Except(afterList);
    }
