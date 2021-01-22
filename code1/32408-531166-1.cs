    public abstract class AbstractPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjectFactory.BuildUp(this);
            this.Do_Load(sender,e); 
            //template method, to enable subclasses to mimic "Page_load" event
 
        }
        //Default Implementation (do nothing)
        protected virtual void Do_Load(object sender, EventArgs e){}
    }
