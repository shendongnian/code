    public class TextBox : System.Web.UI.WebControls.TextBox, System.Web.UI.IPostBackEventHandler
    {
        private static readonly object _clickEvent = new object();
        [System.ComponentModel.Category("Action")]
        public event EventHandler Click
        {
            add { base.Events.AddHandler(_clickEvent, value); }
            remove { base.Events.RemoveHandler(_clickEvent, value); }
        }
        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = (EventHandler)base.Events[_clickEvent];
            if (handler != null) handler(this, e);
        }
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute(System.Web.UI.HtmlTextWriterAttribute.Onclick, base.Page.ClientScript.GetPostBackEventReference(this, null));
        }
        #region IPostBackEventHandler Members
        void System.Web.UI.IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.OnClick(EventArgs.Empty);
        }
        #endregion
    }
***
    <pages>
      <tagMapping>
        <add tagType="System.Web.UI.WebControls.TextBox"
             mappedTagType="{namespace}.TextBox"/>
      </tagMapping>
    </pages>
