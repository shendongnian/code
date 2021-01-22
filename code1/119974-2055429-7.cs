    public class Tab : HtmlGenericControl
    {
        public string Label
        {
            get { return (string)ViewState["Label"] ?? string.Empty; }
            set { ViewState["Label"] = value; }
        }
    }
