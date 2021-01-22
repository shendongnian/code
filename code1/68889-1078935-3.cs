    frmFnC objFnC = new frmFnC();
    objFnC.UserName = txtUserName.Text;
    if (objFnC.ShowDialog() == DialogResult.OK)
    {
        // the user clicked the OK button
    }
    else
    {
        // the user clicked the Cancel button
    }
