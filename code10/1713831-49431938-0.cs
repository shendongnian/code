    public class ID2
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }
    
    public class ID3
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }
    
    public class ID1
    {
        public ID2 ID2 { get; set; }
        public ID3 ID3 { get; set; }
    }
    
    public class ID12
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }
    
    public class ID22
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }
    
    public class ID33
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }
    
    public class ID32
    {
        public ID12 ID1 { get; set; }
        public ID22 ID2 { get; set; }
        public ID33 ID3 { get; set; }
    }
    
    public class Results
    {
        public ID1 ID1 { get; set; }
        public ID32 ID3 { get; set; }
    }
    
    public class RootObject
    {
        public List<string> Nodes { get; set; }
        public Results Results { get; set; }
    }
