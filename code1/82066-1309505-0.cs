    [Cmdlet(VerbsCommunications.Get, "MyCmdlet")]
    public class MyCmdlet : Cmdlet
    {
        [Parameter(Mandatory=true)]
        public string SomeParam {get; set;}
        
        protected override void ProcessRecord()
        {
             WriteObject("The param you passed in was: " + SomeParam);
        }
    
    }
