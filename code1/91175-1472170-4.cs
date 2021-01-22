    public partial class MyUserControl : System.Web.UI.UserControl
    {
        // Event Definition and Raising methods
        ...
        
       protected void Page_Load(object sender, EventArgs e)
       {
           // @@@@ will denote this is an argument I provided.
           string arg = "@@@@" + divClickableDiv.ClientID;
           // Add postback method to onClick 
           divClickableDiv.Attributes.Add("onClick", 
           Page.ClientScript.GetPostBackEventReference(divClickableDiv, arg));
         
           if (IsPostBack)
           {
               // Get event arguments for post back.
               string eventArg = Request["__EVENTARGUMENT"];
               // Determine if postback is a custom postback added by me.
               if (!string.IsNullOrEmpty(eventArg) && eventArg.StartsWith("@@@@"))
               {
                   // Raise the click event for this UserControl if the div
                   // caused the post back.
                   if (eventArg == arg) 
                       OnDivClicked(EventArgs.Empty);
                }
            }
        }
    }
