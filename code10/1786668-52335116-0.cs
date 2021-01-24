    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Stuff> stuff = new List<Stuff>();
            stuff.Add(new Stuff() { Foo = "Foo1", Bar = "Bar1", Data = "Data1" });
            stuff.Add(new Stuff() { Foo = "Foo2", Bar = "Bar2", Data = "Data2" });
            var bindingList = new BindingList<Stuff>(stuff);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string arg = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Form2 form2 = new Form2(arg);
            form2.Show();
            this.Hide();
        }
    }
    public class Stuff
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
        public string Data { get; set; }
    }
