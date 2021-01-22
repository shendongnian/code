    [page.aspx]
    public partial class page : System.Web.UI.Page {
    	protected bool Login(string userName) {
    		System.Collections.Generic.List<string> d = Application["UsersLoggedIn"]
    			as System.Collections.Generic.List<string>;
    		if (d != null) {
    			lock (d) {
    				if (d.Contains(userName)) {
    					// User is already logged in!!!
    					return false;
    				}
    				d.Add(userName);
    			}
    		}
    		Session["UserLoggedIn"] = userName;
    		return true;
    	}
    
    	protected void Logout() {
    		Session.Abandon();
    	}
    }
    [global.asax]
    <%@ Application Language="C#" %>
    <script RunAt="server">
    	void Application_Start(object sender, EventArgs e) {
    		Application["UsersLoggedIn"] = new System.Collections.Generic.List<string>();
    	}
    
    	void Session_End(object sender, EventArgs e) {
    		// NOTE: you might want to call this from the .Logout() method - aswell -, to speed things up
    		string userLoggedIn = Session["UserLoggedIn"] == null ? string.Empty ? (string)Session["UserLoggedIn"];
    		if (userLoggedIn.Length > 0) {
    			System.Collections.Generic.List<string> d = Application["UsersLoggedIn"] 
    				as System.Collections.Generic.List<string>;
    			if (d != null) {
    				lock (d) {
    					d.Remove(userLoggedIn);
    				}
    			}
    		}
    	}
    </script>	
