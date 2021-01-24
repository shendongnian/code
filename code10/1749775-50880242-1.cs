    {
      "data": {
        "aname": {
          "key": 0,
          "value": 10
        },
        "asecondname": {
          "key": 10,
          "value": 5
        }
      }
    }
    public class MyModelRequest
    {
        public Dictionary<string, MyKeyValuePair> Data { get; set; }
    }
    public class MyKeyValuePair
    {
        public int Key { get; set; }
        public int Value { get; set; }
    }
