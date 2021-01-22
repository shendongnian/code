    public string UserName;
    private void btnFn_Click(object sender, EventArgs e)
    {
      UserName = txtUserName.Text;
      frmFnC objFnC = new frmFnC();
      objFnC.txtUserName.Text = UserName;  // SET THE DATA BEFORE SHOWING THE DIALOG
      objFnC.ShowDialog();
    }
