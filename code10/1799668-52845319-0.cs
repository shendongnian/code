    public string SelectedName { get; set; }
    private void selectNameButton_Click(object sender, EventArgs e)
    {
        SelectedName = comboBox1.Text;
        this.Close();
    }
