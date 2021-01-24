    private void btnAddInput_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(textValue))
        {
            //(...)
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = InputData;
            txtInput.Text = "";
        }
        //(...)
