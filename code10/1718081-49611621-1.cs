      protected void Page_Load(object sender, EventArgs e) {
        Label1.Text = Context.User.Identity.IsAuthenticated ? "Hi " + Context.User.Identity.Name + "!" : "Hi Guest!";
        footerYear.Text = DateTime.Now.Year.ToString();
        HyperLink1.Visible = false;
        if (Context.User.Identity.IsAuthenticated) {
          HyperLink1.Visible = !Context.User.IsInRole("student") && !Context.User.IsInRole("teacher") && !Context.User.IsInRole("registrar");
        }
      }
