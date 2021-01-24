    public class Model
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        var list = new List<Model>
        {
            new Model{Id = 1, Text = "Lorem ipsum" },
            new Model{Id = 2, Text = "Lorem ipsum dolor sit amet." },
            new Model{Id = 3, Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
        };
        dataGridView1.DataSource = list;
        dataGridView1.Columns["Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridView1.Columns["Text"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    }
