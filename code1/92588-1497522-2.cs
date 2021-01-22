    public partial class Form1 : Form
    {
        public int Unit { get; set; }
        BindingSource form1BindingSource;
        private void Form1_Load (...)
        {
            form1BindingSource = this;
            textBox1.DataBindings.Add ("Text", form1BindingSource, "Unit");
        }
    }
