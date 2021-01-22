    frmFnC objFnC = new frmFnC();
    objFnC.UserName = txtUserName.Text;
    DialogResult result = objFnC.ShowDialog();
  
    if (objFnC.ShowDialog() == DialogResult.OK)
    {
        // the user clicked the OK button
    }
    else
    {
        // the user clicked the Cancel button
    }
