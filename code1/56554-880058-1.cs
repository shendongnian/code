    public abstract class Application
    {
        public Application() { }
    
        private Dictionary<string, string> _mappings = new Dictionary<string, string>();
        public Dictionary<string, string> Mappings
        {
            get { return _mappings; }
        }
    
        public string AccountNumber { get; set; }
    
        protected abstract void ProvideMappings();        
    }
    
       
    public class Application1 : Application
    {
        protected override void ProvideMappings()
        {
            Mappings.Add("AccountNumber", "TextBox1");
        }
    }
    
    public class Application2 : Application
    {
        protected override void ProvideMappings()
        {
            Mappings.Add("AccountNumber", "TextBox2");
        }
    }
