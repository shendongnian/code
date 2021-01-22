    if (!IsPostBack)
    {
      for(int i = 2000, i <= DateTime.Now.Year; i++)
      {
        MyDropDownList.Items.Add(i.ToString());
      }
    }
