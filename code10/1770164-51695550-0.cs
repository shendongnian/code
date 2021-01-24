    private void btn_logIn_Click(object sender, EventArgs e)
        {          
            string uid = txb_userId.Text;
            string pwd = txb_password.Text;
            string procedureName = "spUsers_Login @Username, @Password";
            string[] paramName = new string[2];
            string[] procParams = new string[2];
    
            paramName[0] = "@Username";
            procParams[0] = uid;
            paramName[1] = "@Password";
            procParams[1] = pwd;
    
            db.OpenConection();
            db.ExecuteProcedure(procedureName, paramName, procParams);
        }
