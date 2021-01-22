    public abstract class Application
    {
        public Application() { }
    
        private Dictionary<string, string> mappings = new Dictionary<string, string>();
        
        public Dictionary<string, string> Mappings
        {
            get { return mappings; }
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
