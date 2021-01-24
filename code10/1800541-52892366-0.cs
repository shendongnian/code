       [CustomAction]
        public static ActionResult CustomAction(Session session)
        {
        #if DEBUG
                System.Diagnostics.Debugger.Launch();
        #endif
                MessageBox.Show("Hello World!" + session[IISSessions.AppPoolName], "External Managed CA");
        
                return ActionResult.Success;
         }
