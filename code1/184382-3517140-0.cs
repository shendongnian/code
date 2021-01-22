    private BindingList<Material> _materials;
    private void Main_Load(object sender, EventArgs e)
    {
        _materials = new BindingList<Material>(db.Materials);
        matList.DataSource = _materials;
        matList.DisplayMember = "Name";
    }
    private void newMat_Click(object sender, EventArgs e)
    {
        AddMaterial form = new AddMaterial();
        if (form.ShowDialog() == DialogResult.OK)
        {
            _materials.Add(form.NewMaterial);
        }
    }
