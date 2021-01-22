    public void Page_Init(object o, EventArgs e)
    {
         if(!string.IsNullOrEmpty(Request.Form["MyButtonName"]))
         {
              A();
         }
    }
