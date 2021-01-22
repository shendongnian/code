    protected void btnSave_Click(object sender, EventArgs e)
    {
      var control = PlaceHolder1.FindControl("Memberuc1") as IMyUserControl;
      if (control != null)
      {
        control.Save();
      }
    }
