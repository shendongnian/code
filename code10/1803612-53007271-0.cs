    //define a couple of classes to hold people and frames
    public class Person
    {
        public string PersonId { get; set; }
        public string TeamId { get; set; }
        public List<Frame> Frames { get; set; }
    
        public Person()
        {
            Frames = new List<Frame>();
        }
    }
    
    public class Frame
    {
        public string N { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string S { get; set; }
    }
