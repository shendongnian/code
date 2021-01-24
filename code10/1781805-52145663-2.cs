    [TestCase("15th Oct 2018")]
    [TestCase("1st Oct 2018")]
    [TestCase("2nd Oct 2018")]
    [TestCase("3rd Oct 2018")]
    [TestCase("3d Oct 2018")]
    public void Action(string dateStr)
    {
        // Act
        var dt = DateTime.ParseExact(Regex.Replace(dateStr, "(th|st|nd|rd|d)", ""), "d MMM yyyy", CultureInfo.CurrentCulture);
        //Assert
        Console.WriteLine(dt);
    }
