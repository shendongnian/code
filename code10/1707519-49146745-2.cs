    private void StudentDeatilsPage_Load(object sender, EventArgs e)
    {
        this.tableTableAdapter.Fill(this.studentsDatabseDataSet.Table);
        LoadData();
    }
    
    private void LoadData()
    {
        List<Employee> studentlist= (ke.SearchStudent(txtname.Text, txtCity.Text)).ToList();
        dataGridView1.DataSource = studentlist;
        dataGridView1.DataBind(); 
    }
