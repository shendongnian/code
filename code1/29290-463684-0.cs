    public partial class ListBoxContainer : System.Web.UI.UserControl
    {
        //declare the event using EventHandler<T>
        public event EventHandler<EventArgs> ListBox_SelectedIndexChanged;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void LstFromControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fire event: the check for null sees if the delegate is subscribed to
            if (ListBox_SelectedIndexChanged != null)
            {
                ListBox_SelectedIndexChanged(sender, e);
            }
        }
    }
