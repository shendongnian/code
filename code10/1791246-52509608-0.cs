    using System.Management.Automation;
    [Cmdlet(VerbsDiagnostic.Test, "Cmdlet")]
    public class TestCmdletCommand : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            HelperMethods.WriteFromHelper(this, "message");
        }
    }
    public static class HelperMethods
    {
        public static void WriteFromHelper(PSCmdlet cmdlet, string message)
        {
            cmdlet.WriteVerbose(message);
        }
    }
