    protected void Page_Load(object sender, EventArgs e) 
    { 
      if (Page.IsPostBack) 
      {
        string usn = UserNameBox.Text; 
        string pss = PassBox.Text; 
        if (usn == "" || pss == "")            
          return; 
        DataClassesDataContext dc = new DataClassesDataContext(); 
        var user = from u in dc.User where u.UserName == usn select u; 
      } 
    }
