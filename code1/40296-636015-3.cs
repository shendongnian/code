    <%@ Application Language="C#" %>
    <script runat="server">        
        void Application_Error(object sender, EventArgs e) 
        {
            Exception ex = Server.GetLastError()
            bool rethrow = ExceptionPolicy.HandleException(ex, "App Exception");
            if (!rethrow)
            {
                Server.ClearError();
            }
    
        }       
    </script>
