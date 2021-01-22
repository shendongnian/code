    Label sample;
    public Form1()
    {
       InitializeComponent();
       sample = new Label();
       sample.Location = new Point(numericUpDown1.Left, numericUpDown1.Bottom);
       sample.Size = numericUpDown1.Size;
       sample.BackColor = Color.Blue;
       Controls.Add(sample);
       numericUpDown1.Value = sample.Width;
    }
    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
       sample.Width = (int)numericUpDown1.Value;
    }
