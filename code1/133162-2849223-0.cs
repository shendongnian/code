    System.Web.UI.Page page = HttpContext.Current.Handler as System.Web.UI.Page;
    if (page != null) {
               page.Unload += (EventHandler)delegate(object s, EventArgs e) {
                          try {
                                     dbCommand.Connection.Close();
                          } catch (Exception) {
                          } finally {
                                     result = null;
                          }
               };
    }
