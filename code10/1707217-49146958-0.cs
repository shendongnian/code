    public partial class Form1 : Form
	{
		private DataGridView _dataGridView = new DataGridView();
		private DataSet _dataSet = new DataSet();
		public Form1()
		{
			InitializeComponent();
			GenerateDataSet();
			CreateDataGridView();
		}
		private void CreateDataGridView()
		{
			var MaterialsColumn = new DataGridViewComboBoxColumn
			{
				DataPropertyName = "MaterialId",
				HeaderText = "Material",
				DataSource = _dataSet.Tables["Materials"],
				DisplayMember = "Name",
				ValueMember = "Id",
				Name = "MaterialColumn",
				ReadOnly = true
			};
			var PricelistsColumn = new DataGridViewComboBoxColumn
			{
				DataPropertyName = "PricelistId",
				HeaderText = "Pricelist",
				DataSource = _dataSet.Tables["Pricelists"],
				DisplayMember = "Name",
				ValueMember = "Id",
				Name = "PricelistColumn"
			};
			_dataGridView.AutoGenerateColumns = false;
			_dataGridView.Columns.AddRange(MaterialsColumn, PricelistsColumn);
			_dataGridView.DataSource = _dataSet.Tables["PricelistAssignments"];
			_dataGridView.Dock = DockStyle.Fill;
			_dataGridView.EditingControlShowing += EditingControlShowing;
			_dataGridView.AllowUserToAddRows = false;
			_dataGridView.AllowUserToDeleteRows = false;
			Controls.Add(_dataGridView);
		}
		private void GenerateDataSet()
		{
			// Create tables
			_dataSet.Tables.Add("Materials");
			_dataSet.Tables["Materials"].Columns.Add("Id", typeof(int));
			_dataSet.Tables["Materials"].Columns.Add("Name", typeof(string));
			_dataSet.Tables.Add("Pricelists");
			_dataSet.Tables["Pricelists"].Columns.Add("Id", typeof(int));
			_dataSet.Tables["Pricelists"].Columns.Add("Name", typeof(string));
			_dataSet.Tables["Pricelists"].Columns.Add("MaterialId", typeof(int));
			_dataSet.Tables.Add("PricelistAssignments");
			_dataSet.Tables["PricelistAssignments"].Columns.Add("MaterialId", typeof(int));
			_dataSet.Tables["PricelistAssignments"].Columns.Add("PricelistId", typeof(int));
			// Populate tables
			_dataSet.Tables["Materials"].Rows.Add(1, "Steel");
			_dataSet.Tables["Materials"].Rows.Add(2, "Plastic");
			_dataSet.Tables["Pricelists"].Rows.Add(1, "PL Steel 1", 1);
			_dataSet.Tables["Pricelists"].Rows.Add(2, "PL Plastic 1", 2);
			_dataSet.Tables["Pricelists"].Rows.Add(3, "PL Steel 2", 1);
			_dataSet.Tables["Pricelists"].Rows.Add(4, "PL Plastic 2", 2);
			_dataSet.Tables["Pricelists"].Rows.Add(5, "PL Plastic 3", 2);
			_dataSet.Tables["PricelistAssignments"].Rows.Add(1, 3);
			_dataSet.Tables["PricelistAssignments"].Rows.Add(1, 1);
			_dataSet.Tables["PricelistAssignments"].Rows.Add(2, 4);
		}
		private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			var grid = (DataGridView)sender;
			if (grid.CurrentCell.ColumnIndex == 1) // Pricelist column
			{
				var combo = (DataGridViewComboBoxEditingControl)e.Control;
				var selectedValue = combo.SelectedValue;
				var data = _dataSet.Tables["Pricelists"].AsDataView();
				data.RowFilter = "MaterialId = " + grid.CurrentRow.Cells[0].Value.ToString();
				combo.DataSource = data;
				combo.SelectedValue = selectedValue;
			}
		}
	}
