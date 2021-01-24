    public partial class ProductPartsForm : Form
    {
        private int _productID;
        private DataSet1 _data;
        public ProductPartsForm(DataSet1 data, DataRowView productRowView)
        {
            var productRow = (DataSet1.ProductRow)productRowView.Row;
            _productID = productRow.ID;
            _data = data;
            InitializeComponent();
            productBindingSource.DataSource = productRowView;
            assignedPartBindingSource.DataSource = _data;
            assignedPartBindingSource.DataMember = "Part";
            assignedPartsListBox.DisplayMember = "Name";
            unassignedPartBindingSource.DataSource = _data;
            unassignedPartBindingSource.DataMember = "Part";
            unassignedPartsListBox.DisplayMember = "Name";
        }
        private void ProductPartsForm_Load(object sender, EventArgs e)
        {
            UpdateFilters();
            UpdateUI();
        }
        private void assignButton_Click(object sender, EventArgs e)
        {
            var partRowView = (DataRowView)unassignedPartBindingSource.Current;
            var partRow = (DataSet1.PartRow)partRowView.Row;
            var productRowView = (DataRowView)productBindingSource.Current;
            var productRow = (DataSet1.ProductRow)productRowView.Row;
            _data.ProductPart.AddProductPartRow(productRow, partRow);
            UpdateFilters();
            UpdateUI();
        }
        private void unassignButton_Click(object sender, EventArgs e)
        {
            var partRowView = (DataRowView)assignedPartBindingSource.Current;
            var partRow = (DataSet1.PartRow)partRowView.Row;
            var productPartRow = _data.ProductPart
                .Single(pp => pp.ProductID == _productID && pp.PartID == partRow.ID);
            _data.ProductPart.RemoveProductPartRow(productPartRow);
            UpdateFilters();
            UpdateUI();
        }
        private void UpdateFilters()
        {
            var assignedIds = _data.ProductPart
                .Where(pp => pp.ProductID == _productID)
                .Select(pp => pp.PartID.ToString());
            if (assignedIds.Any())
            {
                assignedPartBindingSource.Filter = $"ID IN ({string.Join(",", assignedIds)})";
                unassignedPartBindingSource.Filter = $"ID NOT IN ({string.Join(",", assignedIds)})";
            }
            else
            {
                assignedPartBindingSource.Filter = "FALSE";
                unassignedPartBindingSource.RemoveFilter();
            }
        }
        private void UpdateUI()
        {
            assignedPartsListBox.Refresh();
            unassignedPartsListBox.Refresh();
            assignButton.Enabled = unassignedPartsListBox.Items.Count > 0;
            unassignButton.Enabled = assignedPartsListBox.Items.Count > 0;
        }
    }
