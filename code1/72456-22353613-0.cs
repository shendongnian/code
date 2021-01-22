    protected void Page_Load(object sender, EventArgs e) {
      var employee = RequestPermission();
      if (!employee.Authorized) {
        Response.Redirect(Request.UrlReferrer.ToString());
      }
      if (!IsPostBack) {
        //Load the grid for the initial page
      }
    }
