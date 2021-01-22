    private void Button1_Click(object sender, EventArgs MyEventArgs)
    {
      // Find control on page.
      TextBox myControl1 = (TextBox) FindControl("Label1");
      if(myControl1!=null)
      {
         string message = myControl1.Text;
      }
    }
