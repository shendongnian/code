    [Cmdlet(VerbsCommon.Get, "Double")]
    public class GetDouble : Cmdlet
    {
        [Parameter]
        public int SomeInput { get; set; }
        protected override void ProcessRecord()
        {
            WriteObject(SomeInput * 2);
        }
    }
