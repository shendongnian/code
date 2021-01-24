    // SomeRule only contains data. Much simpler
    [Serializable]
    public class SomeRule 
    {
        [XmlAttribute("Attribute1")]
        public string Attribute1 {get;set;}
        [XmlAttribute("Attribute2")]
        public string Attribute2 { get; set; }
    }
    // Moved behavior to new class. This class can be injected
    // into consumers, as usual.
    public class SomeRuleHandler : IRuleHandler<SomeRule>
    {
        private readonly ISomeService m_someService;
        // There's now just one constructor left
        public SomeRuleHandler(ISomeService someService)
        { 
            m_someService = someService ?? throw new ArgumentNullException("someService");
        }
        public void DoSomething(SomeRule rule)
        {
            m_someService.DoStuff(rule.Attribute1);
        }
    }
