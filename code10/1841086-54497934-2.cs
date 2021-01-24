    public interface ITestData
    {
        string Field { get; set; }
        string FieldName { get; set; }
        string Type { get; set; }
    }
    public class TestData : ITestData
    {
        public string Field { get; set; }
        public string FieldName { get; set; }
        public string Type { get; set; }
    }
