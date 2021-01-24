    public void add()
    {
        var con = new DBConnection();
        try
        {
            for (int i = 0; i < listBServices.Items.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("SELECT price FROM price WHERE service = '" +
                    listBServices.Items.ToString() + "';", con.Connection);
                SqlDataReader rd = cmd.ExecuteReader();
    
                while (rd.Read())
                {
                    int price = rd.GetInt32(0);
                    listBPrice.Items.Add(price.ToString());
                }
    
                rd.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
