    public partial class WebForm1 : System.Web.UI.Page
    	{
        public void SetPageOutput(string text)
    		{
    			// writes to page
    			this.PageOut.Text = text;
    		}
    
    		public void SetMaster(string text)
    		{
    			// writes to Master Page
    			this.Master.SecondMasterString(text);
    		}
    }
