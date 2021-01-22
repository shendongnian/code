     public class ConfirmationLinkButton : LinkButton
    {
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            string script = "confirmAsync('" + ConfirmationMessage.Replace("'", "\\'") + "', " + Callback() + ");" +
                            "return false;";
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, script, false);
        }
        private string Callback()
        {
            return "(data) => { if (data===true) {" + Page.ClientScript.GetPostBackEventReference(this, "") + "}}";
        }
        public string ConfirmationMessage { get; set; }
    }
