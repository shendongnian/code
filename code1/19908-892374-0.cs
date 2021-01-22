        int sal = 0;
        OracleConnection myconn = new OracleConnection(ConfigurationManager.AppSettings["con"].ToString());
        cmd = new OracleCommand("SP_student_MAST", myconn);
        cmd.CommandType = CommandType.StoredProcedure;
        OracleParameter param1 = null, param2 = null, param3 = null, param4 = null, param5 = null;
        try
        {
            myconn.Open();
           trans = myconn.BeginTransaction();
            cmd.Transaction = trans;
            //param1 = new OracleParameter("pSNo", OracleType.VarChar, 5);
            //param1.Value ="";
            //cmd.Parameters.Add(param1);
            param2 = new OracleParameter("pSName", OracleType.VarChar, 10);
           // param2.Value = "Saravanan";
            param2.Value = TextBox1.Text;
            cmd.Parameters.Add(param2);
            param3 = new OracleParameter("pENo", OracleType.VarChar,5);
            param3.Value = TextBox2.Text;
            cmd.Parameters.Add(param3);
            param4 = new OracleParameter("pEName", OracleType.VarChar,10);
           // param4.Value = "Sangeetha";
            param4.Value = TextBox3.Text;
            cmd.Parameters.Add(param4);
            param5 = new OracleParameter("pSENo", OracleType.Char, 5);
            param5.Value = "";
            cmd.Parameters.Add(param5);
            sal = cmd.ExecuteNonQuery();
            trans.Commit();
            Response.Write("Record Saved");
            myconn.Close();
           // rollbackvalue = 0;
        }
        catch (Exception ex)
        {
            Response.Write("Not saved.RollBacked");
            trans.Rollback();
            //rollbackvalue = 1;
        }
        string cs = Convert.ToString(sal);
        return cs;
    }
