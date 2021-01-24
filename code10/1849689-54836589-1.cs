    [Cmdlet(VerbsCommunications.Write, "Greeting")]
    [OutputType(typeof(GreetingClass))]
    public class WriteGreeting : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Greeting { get; set; }
        [Parameter]
        [Alias("Who")]
        public string ToWhom { get; set; } = "World";
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteVerbose("Creating and returning the Greeting Object");
            var greeting = new GreetingClass {Greeting = Greeting, ToWhom = ToWhom};
            WriteObject(greeting);
        }
    }
