      public partial class MyPage : System.Web.UI.Page
      { 
        protected void Page_Load(object sender, EventArgs e)
        {      
          Thread myThread = new Thread(new ParameterizedThreadStart(ThreadMethod));
          myThread.Start(HttpContext.Current.User); 
        }
    
        private void ThreadMethod(object state)
        {
          WindowsPrincipal principal = state as WindowsPrincipal;
    
          WindowsImpersonationContext impersonationContext = null;
          try
          {
            if (principal != null)
            {
              Thread.CurrentPrincipal = principal;
              impersonationContext = WindowsIdentity.Impersonate(((WindowsIdentity)principal.Identity).Token);
            }
    
            // Do your user specific stuff here...
          }
          finally
          {
            if (impersonationContext != null)
            {
              impersonationContext.Undo();
            }
          }
        }
      }
