    public class CtlTest : WebControl, ICallbackEventHandler
    {
        private static readonly object EventClick = new object();
        public CtlTest() : base(HtmlTextWriterTag.A) { }
        public event EventHandler Click
        {
            add { base.Events.AddHandler(EventClick, value); }
            remove { base.Events.RemoveHandler(EventClick, value); }
        }
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Href, this.Page.ClientScript.GetCallbackEventReference(this, null, "Success", null));
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            base.RenderContents(writer);
            writer.Write("Submit Query");
        }
        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = this.Events[EventClick] as EventHandler;
            if (handler != null)
                handler(this, e);
        }
        #region ICallbackEventHandler Members
        string ICallbackEventHandler.GetCallbackResult()
        {
            return DateTime.Now.ToString();
        }
        void ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
        {
            this.OnClick(EventArgs.Empty);
        }
        #endregion
    }
