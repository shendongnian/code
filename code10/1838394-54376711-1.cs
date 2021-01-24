    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) // This will run when the page is loaded but not from a post back / button click etc (e.g. from your page refresh)
        {
          this.SetButtonState();
        }
        else
        {
          // use this for things you want to happen on postback only
        }
    }
    
    private void SetButtonState()
    {
       if (Session["signup"] == null)
       {
          _signupbutton.Text = "??? ??? / ????";
          _defaultuser.Visible = true;
       }
       else
       {
          _signupbutton.Text = "<i class=\"fa\"></i> " + Session["signup"].ToString();
          _signedup.Visible = true;
       }
    }
    
    protected void _userlogout_Click(object sender, EventArgs e)
    {
        Session.Remove("signup");
    
        // Update your button state
        this.SetButtonState();
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Add("signup", "????? ??????????");
    
        // Update your button state
        this.SetButtonState();
    }
