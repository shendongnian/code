    ComboBoxItem comboItem = new ComboBoxItem();
    item2.Text = "Admin";
    item2.Value = "Admin";
    
    ComboBoxItem comboItem2 = new ComboBoxItem();
    item2.Text = "Employee";
    item2.Value = "Employee";
    
    List<ComboBoxItem> items = new List<ComboBoxItem> { comboItem, comboItem2 };
    
    this.yourComboBox.DisplayMember = "Text";
    this.yourComboBox.ValueMember = "Value";
    this.yourComboBox.DataSource = items;
    private void aBtnSave_Click(object sender, EventArgs e)
        {
            ComboboxItem selectedString = (ComboboxItem)yourComboBox.SelectedItem;
            var userPosition= selectedString.Value;
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Do not delete\insertUserExample.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "INSERT INTO userData (firstName,lastName,userName,password,contactNo,position) values('" + this.aTxtFirstName.Text + "', '" + this.aTxtLastName.Text + "', '" + this.aTxtUserName.Text + "', '" + this.aTxtPassword.Text + "', '" + this.aTxtContact.Text + "', '" + userPosition + "');";
            SqlConnection sqlcon = new SqlConnection(conString);
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);
            SqlDataReader sqlReader;
    
            try {
                sqlcon.Open();
                sqlReader = sqlcom.ExecuteReader();
                MessageBox.Show("User is Saved!");
    
                while (sqlReader.Read()) {
    
                }
    
                aTxtFirstName.Clear();
                aTxtLastName.Clear();
                aTxtUserName.Clear();
                aTxtPassword.Clear();
                aTxtContact.Clear();
    
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
    class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
