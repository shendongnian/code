    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<select> sl = new List<select>();
                sl.Add(new select() { Text = "", Value = "" });
                sl.Add(new select() { Text = "AAA", Value = "aa" });
                sl.Add(new select() { Text = "BBB", Value = "bb" });
                comboBox1.DataSource = sl;
                comboBox1.DisplayMember = "Text";
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                select sl1 = comboBox1.SelectedItem as select;
                t1.Text = Convert.ToString(sl1.Value);
    
            }
        }
    }
