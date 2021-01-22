    public class Item
    {
        public Dictionary<string, string> Data
        { get; set; }
        
        public string Name { get { return Data["lastname"]; } }
    }
    //Call by: i.Name.StartsWith("abc");
