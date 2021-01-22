    public class SC : ScriptControl
    {
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            return null;
        }
            protected override IEnumerable<ScriptReference> GetScriptReferences()
            {
                return null;
            }
        }
        //... Page code
            protected void Page_PreRender(object sender, EventArgs e)
            {
                var sc = new SC();
                var sc1 = new SC();
                Page.Form.Controls.Add(sc);
                Page.Form.Controls.Add(sc1);
            }
