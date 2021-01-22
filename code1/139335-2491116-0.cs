	public partial class Form1 : Form
	{
		DataEntry[] data = new[]{
			new DataEntry(){Name = "A", Entries = new []{ "1", "2", "3", "4"}},
			new DataEntry(){Name = "B", Entries = new []{ "1", "2", "3"}}};
		string[] cols = new[] { "col1", "col2" };
		public Form1()
		{
			InitializeComponent();
			dataGridView1.AutoGenerateColumns = false;
			var nameCol = new DataGridViewTextBoxColumn();
			nameCol.DataPropertyName = "Name";
			var entriesCol = new DataGridViewComboBoxColumn();
			entriesCol.Name = "Entries";
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameCol, entriesCol });
			dataGridView1.DataSource = data;
			dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);
		}
		void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells["Entries"];
				DataEntry entry = dataGridView1.Rows[i].DataBoundItem as DataEntry;
				comboCell.DataSource = entry.Entries;
				comboCell.Value = entry.Entries.First();
			}
		}
	}
	public class DataEntry
	{
		public string Name { get; set; }
		public IEnumerable<string> Entries { get; set; }
	}
