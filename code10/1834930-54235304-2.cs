    public class Inputs
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    internal BindingList<Inputs> InputData = new BindingList<Inputs>();
    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.DataSource = InputData;
    }
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
        }
        else
        {
            MessageBox.Show("Not a valid value");
        }
    }
