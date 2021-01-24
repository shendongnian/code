    try
    { 
        Configuration configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        configuration.AppSettings.Settings.Add("Path" + i, textBox2.Text);
        configuration.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
        
        dt.Rows.Add(textBox2.Text);
        this.dataGridView1.DataSource = dt;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Add is not complete.\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    } 
