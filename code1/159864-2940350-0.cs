    [Export( typeof( IRule ) )]  
    public class RuleInstance : IRule  
    {
        puliic void DoIt() 
        { }
    
        public string Name { get; set; }
    }
    public class Program
    {
        [Import(typeof( IRule ))]
        public IRule instance { get; set; }
        public void Run()
        {
            // Load the assemblies here
        
            instance.Name = "Rule Instance 3";
        }             
    }
