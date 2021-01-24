    [Test]
    [TestCaseSource("MySourceProperty")]
    public void SendDataToAgregator_GoodVariables_ReturnsOn(string agrID,string devID, Dictionary<TypeMeasurement, double> measurement)
    {
    }
    static object[] MySourceProperty 
    {
        get
        {
            var measurement = new Dictionary<TypeMeasurement, double>();
            // Do what you want with your dictionary
            // The order of element in the object my be the same expected by your test method
            return new object[1]
            { 
               new object[] { "agr1", "askdwskdls", measurement }
            }
        }
    };
