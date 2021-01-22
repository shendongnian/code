    private void ExceptionForm_Load(object sender, EventArgs e)
    {
      DbErrorException specificException = _exception as DbErrorException;
      if (specificException != null)
      {
         txtErrorMessage.Text += "SqlSyntax=" + specificException.SqlSyntax;
      }
    }
