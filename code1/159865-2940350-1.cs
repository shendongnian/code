     [Export( typeof( IRule ) )]  
    public class RuleInstance : IRule  
    {
        puliic void DoIt() 
        { }
        public void Initialise()
        {
            // Load our name from the host, this cannot be done in the constructor
            string name = Host.GetName(//some parameters?)
        }
    
        public IHost Host { get; set; }
        public string Name { get; set; }
    }
    public interface IHost
    {
        string GetName(//some parameters?);
    }
    public class Program : IHost
    {
        [Import(typeof( IRule ))]
        public IRule instance { get; set; }
        public void Run()
        {
            // Load the assemblies here       
            // Make sure the plugins know where the host is...
            instance.Host = this;
        }             
    }
