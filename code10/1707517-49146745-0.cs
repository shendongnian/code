         private void StudentDeatilsPage_Load(object sender, EventArgs e)
            {
              
                this.tableTableAdapter.Fill(this.studentsDatabseDataSet.Table);
     LoadData();
    }
    
      private void LoadData()
            {
                List<Employee> empList = (ke.SearchEmployee(txtname.Text, txtCity.Text)).ToList();
                dataGridView1.DataSource = empList;
                dataGridView1.DataBind(); }
