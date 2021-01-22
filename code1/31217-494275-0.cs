    public class SmokingCalc : ScriptControl
    {
        protected override void CreateChildControls()
        {
            this.Controls.Add(costTextbox);
        }
        protected override IEnumerable<ScriptDescriptor>
                GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("SmokingCalc.SmokingCalc", this.ClientID);
            yield return descriptor;
        }
        // Generate the script reference
        protected override IEnumerable<ScriptReference>
                GetScriptReferences()
        {
            yield return new ScriptReference("SmokingCalc.SmokingCalc.js", this.GetType().Assembly.FullName);
        }
        protected HtmlTextWriter htmlWriter;
        protected TextBox costTextbox;
        protected TextBox amountTextbox;
        protected TextBox yearsTextbox;
        protected Button submitButton;
    }
