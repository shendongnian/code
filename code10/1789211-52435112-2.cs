    public class MyTask
    {
        public DateTime Property1 {get;set;} // property1 will be read as a DateTime
        public string Property2 {get;set;} // property2 will be read as a string
    }
    MyTask _task = JsonConvert.DeserializeObject<MyTask>(response_json);
