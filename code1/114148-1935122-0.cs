    [System.Web.UI.ToolboxData("<{0}:FormView runat=\"server\" />")]
    public class FormView : System.Web.UI.WebControls.FormView
    {
    
        private static readonly object _itemClickEvent = new object();
    
        [System.ComponentModel.Category("Action")]
        public event EventHandler<System.Web.UI.WebControls.FormViewCommandEventArgs> ItemClick
        {
            add { base.Events.AddHandler(_itemClickEvent, value); }
            remove { base.Events.RemoveHandler(_itemClickEvent, value); }
        }
    
        protected virtual void OnItemClick(System.Web.UI.WebControls.FormViewCommandEventArgs e)
        {
            EventHandler<System.Web.UI.WebControls.FormViewCommandEventArgs> handler = base.Events[_itemClickEvent] as EventHandler<System.Web.UI.WebControls.FormViewCommandEventArgs>;
            if (handler != null) handler(this, e);
        }
    
        protected override bool OnBubbleEvent(object source, EventArgs e)
        {
            this.OnItemClick((System.Web.UI.WebControls.FormViewCommandEventArgs)e);
            return base.OnBubbleEvent(source, e);
        }
    
    }
