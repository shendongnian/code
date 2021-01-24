    [Serializable]
    public class SomeRule 
    {
        [XmlAttribute("Attribute1")]
        public string Attribute1 {get;set;}
        [XmlAttribute("Attribute2")]
        public string Attribute2 { get; set; }
        // No more constructors. The dependency is supplied in the method,
        // but *not* stored.
        public void DoSomething(ISomeService someService)
        {
            someService.DoStuff(Attribute1);
        }
    }
