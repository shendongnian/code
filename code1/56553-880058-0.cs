    public interface IApplication
    {
        string AccountNumber { get; set; }        
    }
    
    public class Application1 : IApplication
    {
        [ITextField("TextBox1")]
        public string AccountNumber { get; set; }
    }
    
    public class Application2 : IApplication
    {
        [ITextField("TextBox2")]
        public override string AccountNumber { get; set; }
    }
