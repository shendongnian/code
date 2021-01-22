    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            list.Add(1, "one");
            list.Add(2, "two");
            list.Add(3, "three");
            Dictionary<int, string> list2 = Deserialize(Serialize(list));
        }
        public  string Serialize(Dictionary<int, string> classObject)
        {
            StringBuilder output = new StringBuilder();
            output.Append("<DictionaryIntString>");
            foreach (int key in classObject.Keys)
            {
                output.Append(String.Format("<Key value=\"{0}\">",key));
                output.Append(String.Format("<Value>{0}</Value></Key>", classObject[key]));
            }
            output.Append("</DictionaryIntString>");
            return output.ToString();
           
        }
        public Dictionary<int, string> Deserialize(string input)
        {
            Dictionary<int, string> output = new Dictionary<int, string>();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(input);
            foreach (XmlNode node in xml.GetElementsByTagName("Key"))
            {
                output.Add(Int32.Parse(node.Attributes["value"].InnerText),node.FirstChild.InnerText);
                
            }
            return output;
        }
    }
