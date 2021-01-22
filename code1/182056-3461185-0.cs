    protected void Page_Load()
    {
      if (variableToSwitchOn == true)
      {
        button1.Visible = true;
        button2.Visible = false;
      }
      else
      {
        button1.Visible = false;
        button2.Visible = true;
      }
    }
