    public partial class Form1 : Form
    {
        class MyData {
            public int Unit { get; set; }
        }
        MyData form1Data;
        BindingSource form1BindingSource;
        private void Form1_Load (...)
        {
            form1BindingSource = form1Data;
            textBox1.DataBindings.Add ("Text", form1BindingSource, "unit");
        }
    }
