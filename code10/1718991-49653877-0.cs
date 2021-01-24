    public class Item {
        public Int32 ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String DeviceName { get; set; }
        public TimeSpan Time { get; set; }
        public Item(XElement xElement) {
            Load(xElement);
        }
        public void Load(XElement xElement) {
            // your code to grab values goes here
        }
        public XElement ToXElement() {
            // your code to create the xml representation goes here
        }
    }
