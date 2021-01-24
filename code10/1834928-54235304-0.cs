    public class Inputs
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    internal BindingList<Inputs> InputData = new BindingList<Inputs>();
    private void btnAddInput_Click(object sender, EventArgs e)
    {
        string textValue = txtInput.Text.Trim();
        if (!string.IsNullOrEmpty(textValue))
        {
            InputData.Add(new Inputs() {
                Name = textValue,
                Value = "[Whatever this is]"
            });
            txtInput.Text = "";
            dataGridView1.DataSource = InputData;
        }
        else
        {
            MessageBox.Show("Please enter a parameter value", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
