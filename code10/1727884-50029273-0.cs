    private async void button26_Click(object sender, EventArgs e)
    {
        //why check the SAME textbox twice?
        // You should give MEANINGFUL NAMES to your controls, rather than leaving them at the default
        if (string.IsNullOrEmpty(textBox62.Text) || string.IsNullOrEmpty(textBox62.Text)) 
        {
            label77.Visible = true;
            label77.Text = "Поля должны быть заполнены!";
            return;
        }
        label77.Visible = false;
        string sql = "INSERT INTO [Policlinic] (Name, Address, Phone) VALUES ( @Name, @Address, @Phone);";
        using (var con = new SqlConnection("connection string here"))
        using (var cmd = new SqlCommand(sql, con))
        {  
            //Use exact database column types and lengths here
            // DON'T trust ADO.Net to guess these types correctly.
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 20).Value = textBox62.Text;
            command.Parameters.Add("@Address", SqlDbType.NVarChar, 80).Value =  textBox62.Text;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 14).Value =  textBox62.Text;
            con.Open()
            await command.ExecuteNonQueryAsync();
        }
    }
