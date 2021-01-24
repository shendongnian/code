        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
    if (IsPostBack){
            OleDbConnection conn = new OleDbConnection();
            conn.Open();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(@"\App_Data") + @"\JipEnJanneke.mdb";
    
    
            OleDbCommand cmd1 = new OleDbCommand("Select (Prijs, Jaartal, ISBN) from JipEnJanneke where Titel = @Titel", conn);
            cmd1.Parameters.AddWithValue("@Titel", DropDownList1.SelectedValue.ToString());
            OleDbDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                lbl_Prijs.Text = rd["Prijs"].ToString();
                lbl_Jaar.Text = rd["Jaartal"].ToString();
                lbl_Isbn.Text = rd["ISBN"].ToString();
            }
            conn.Close();
    }
    }
