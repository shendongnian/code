    void Main()
    {
        List<CustomerData> customerdata = new List<CustomerData>();
        var binaryFormatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, customerdata);
        var result = memoryStream.ToArray();
    }
    
    [Serializable]
    public class CustomerData
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerState { get; set; }
        public int ProductId { get; set; }
        public int QuantityBought { get; set; }
    }
