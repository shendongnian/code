    protected void datasource_Inserting(object sender, SqlDataSourceCommandEventArgs e) {
                ASCIIEncoding encoding = new ASCIIEncoding();
                ControlParameter cp = new ControlParameter("@password", DbType.Binary, "ctl00$ContentPlaceHolder$ctl01$frmStudents$txtPassword", "Text");
                FormView frmStudents = (FormView)FindControl("frmStudents");
                TextBox txtPassword = (TextBox)(frmStudents.FindControl("txtPassword"));
    
                e.Command.Parameters.Add("password", DbType.Binary, encoding.GetBytes(Cryptogrpahy.Encrypt(txtPassword.Text, basepage.crypt_password)).ToString());
            }
