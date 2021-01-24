    public void PrimeTest() {
        //Arange
        int number = 738;
        string expectedFactors1 = "2, 3, 3, 41";
        //stream and writer used to intercept console output
        var memoryStream = new MemoryStream();
        var writer = new StreamWriter(memoryStream);
        Console.SetOut(writer);
        //Act
        Primes.Program.PrimeEvaluator(number);
        //Assert
        memoryStream.Position = 0; //reset position to read stream
        string actual = new StreamReader(memoryStream).ReadToEnd();
        Assert.AreEqual(expectedFactors1, actual);
    }
