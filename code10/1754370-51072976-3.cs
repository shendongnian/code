    if (!IsPostBack){
       OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(@"\App_Data") + @"\JipEnJanneke.mdb";
            //conn.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0; Data Source=" + Server.MapPath(@"\App_Data") + @"\JipEnJanneke.mdb";
    
            lblConnectionFeedback.Text = "";
            try
            {
                conn.Open();
                lblConnectionFeedback.Text += "Connection is: " + conn.State.ToString();
    
                // HIER QUERY
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Boeken";
    
                OleDbDataReader rd = cmd.ExecuteReader();
    
                DropDownList1.DataSource = rd;
                DropDownList1.DataTextField = "Titel";
                DropDownList1.DataValueField = "Titel";
                DropDownList1.DataBind();
                rd.Close();
    
                conn.Close();
    
            }
            catch (Exception exc)
            {
                lblConnectionFeedback.Text = exc.Message;
            }
            finally
            {
                conn.Close();
                lblConnectionFeedback.Text += "<br />Connection is: " + conn.State.ToString();
            }
    }
