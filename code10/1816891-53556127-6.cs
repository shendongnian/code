    var appConf = System.Configuration.ConfigurationManager.AppSettings;
    var count = appConf.Count;
    try
    {
        // As OP commented this line fixed the problem
        value = null;
    	Configuration configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
    	configuration.AppSettings.Settings.Add("Path" + count, textBox2.Text);
        configuration.Save(ConfigurationSaveMode.Modified);
    	
        ConfigurationManager.RefreshSection("appSettings");
        dt.Rows.Add(textBox2.Text);
        this.dataGridView1.DataSource = dt;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Add is not complete.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
