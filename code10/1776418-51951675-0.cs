    private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DataRow AutoFillItems in GetAutoComplete("CITIES", comboBox1.Text).Rows)
            {
                AutoFillCities.Add(AutoFillItems[0].ToString());
            }
            foreach (string item in AutoFillCities)
            {
                comboBox1.AutoCompleteCustomSource.Add(item);
            }
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
