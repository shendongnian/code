    private List<SubCategory> _allSubCategories;
    private void SInfo_Load(object sender, EventArgs e)
    {
        using (var context = new StBaseSQLEntities())
        {
            metroComboBox1.DataSource = context.Category.ToList();
            metroComboBox1.DisplayMember = "cat_name";
            metroComboBox1.ValueMember = "cat_id";
            //SubCategory
            _allSubCategories = context.SubCategory.ToList();
            metroComboBox2.DataSource = _allSubCategories;
            metroComboBox2.DisplayMember = "scat_name";
            metroComboBox2.ValueMember = "scat_id";
        }
    }
