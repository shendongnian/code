    public class MyClass
        {
          public string StringValue{ get; set; }
          public TestMessage MessageTest { get; set; }
        }
        public class TestMessage 
        {
          [JsonProperty("")]
          public string[] APIResponse{ get; set; }
        }
