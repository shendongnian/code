    public partial class MyWebPage:  System.Web.UI.Page     
    {
        static void Page_Load(object sender, EventArgs e)         
        {
             try 
             {
                 // asp.Net Page Load code here ...
             }
             catch(MyMainCustomApplicationException X)
             {
                 jsMsgBox("An Error was encountered while " +
                          "trying to add a new user.");        
                 lblInfo.Text = X.Message;        
                 lblInfo.Visible = true;
             }
             catch(Exception eX) 
             {  
                  // Maybe Log it here...
                  throw;   // Important to retrhow all unexpected exceptions to
                           // MAKE web page crash !! as you have no idea
                           // whether web app is in consistent state now.
             }
        }
    }
  
