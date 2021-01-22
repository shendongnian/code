    if (!IsPostBack)
    {
      if (Mode == DataBoundControlMode.Insert && Column.DefaultValue != null)
      {
          TextBox1.Text = Column.DefaultValue.ToString();
      }
    }
