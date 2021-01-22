    // Create a new CarKeyValuePair in your web service project
    public struct CarKeyValuePair
    {
        public string Key { get; set; }
        public CarType CarType { get; set; }
    }
    // Change your web method to use this instead of KeyValuePair
    [WebMethod]
    public void DestroyCars(CarKeyValuePair[] cars)
    {
        // Implementation here
    }
