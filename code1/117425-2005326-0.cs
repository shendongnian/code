    public class FooControl : Control
    {
        public string Bar
        {
            get { return ViewState["Bar"] as string; }
            set { return ViewState["Bar"] = value; }
        }
    }
