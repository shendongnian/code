    protected void Page_Init(object sender, EventArgs e)
    {
         string ip = this.Request.UserHostAddress;
         if (ip != 127.0.0.1)
         {
             context.Response.StatusCode = 403; // forbidden
         }
    }
