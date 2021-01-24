    using Newtonsoft.Json;
    public partial class frmSampleJson : Form
    {
        public frmSampleJson()
        {
            InitializeComponent();
        }
        private void frmSampleJson_Load(object sender, EventArgs e)
        {
            //string strServiceStatus = ServiceStatus();
            string Json = File.ReadAllText(@"d://read.txt").ToString();
            JsonDataValue jdv = JsonConvert.DeserializeObject<JsonDataValue>(Json);
            //Use jdv.id to get id or any value inside.
         }
    }
    
    public class Meta
    {
        public string versionId { get; set; }
        public DateTime lastUpdated { get; set; }
    }
    public class Link
    {
        public string relation { get; set; }
        public string url { get; set; }
    }
    public class Tag
    {
        public string system { get; set; }
        public string code { get; set; }
    }
    public class Meta2
    {
        public string versionId { get; set; }
        public DateTime lastUpdated { get; set; }
        public List<Tag> tag { get; set; }
    }
    public class Name
    {
        public string use { get; set; }
        public string family { get; set; }
        public List<string> given { get; set; }
        public List<string> prefix { get; set; }
    }
    public class Resource
    {
        public string resourceType { get; set; }
        public string id { get; set; }
        public Meta2 meta { get; set; }
        public List<Name> name { get; set; }
    }
    public class Search
    {
        public string mode { get; set; }
    }
    public class Entry
    {
        public string fullUrl { get; set; }
        public Resource resource { get; set; }
        public Search search { get; set; }
    }
    public class JsonDataValue
    {
        public string resourceType { get; set; }
        public string id { get; set; }
        public Meta meta { get; set; }
        public string type { get; set; }
        public int total { get; set; }
        public List<Link> link { get; set; }
        public List<Entry> entry { get; set; }
    }
