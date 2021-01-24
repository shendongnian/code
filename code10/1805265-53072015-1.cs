    public class DetectionBox
    {
        public string name { get; set; }
        public List<double> bbox { get; set; }
        public int id { get; set; }
    }
    public class Content
    {
        public int detections { get; set; }
        public List<DetectionBox> detection_boxes { get; set; }
        public string timestamp { get; set; }
        public string person_id { get; set; }
        public string features { get; set; }
    }
    public class Data
    {
        public Content content { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int age { get; set; }
    }
    Data data = JsonConvert.DeserializeObject<Data>(json);
