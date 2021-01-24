    private void btnAddNewObjectsButton_Click(object sender, EventArgs e)
            {
                AddNewObjectsForm form2 = new AddNewObjectsForm();
                form2.ShowDialog();
                if (form2.isSuccess)
                {
                    this.myComboBox.DataSource = null;
                    this.myComboBox.Items.Clear();
                    this.myComboBox.DataSource = db.Object.ToList();//If you work with Entity frame work
                    cmbCustomer.ValueMember = "Id";
                    cmbCustomer.DisplayMember = "Name";
                }
            }
    
