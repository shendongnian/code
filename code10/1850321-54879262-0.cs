    public void JsonDeserializeTesting() {
        var testingModal = new TestingModal{Id = 1,Name = "Eminem",};
        var serializeObject = JsonConvert.SerializeObject(testingModal);
        var deserializeObject = JsonConvert.DeserializeObject<TestingModal>
        (serializeObject);
        Console.WriteLine($"{deserializeObject}");
    }
    public class TestingModal{
        public long Id { get; set; }
        public string Name { get; set; }
    }
