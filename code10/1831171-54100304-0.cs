    private void InitializeDataBinding()
    		{
    			SelectedPerson = PersonList[0];
    
    			var bindingSource = new BindingSource();
    			bindingSource.DataSource = PersonList;
    
    			comboBox.DisplayMember = "FirstName";
     			comboBox.DataSource = bindingSource;
    
    			textBoxFirstName.DataBindings.Add("Text", bindingSource, "FirstName");
    			textBoxLastName.DataBindings.Add("Text", bindingSource, "LastName");
    		}
    
    private void comboBox_TextChanged(object sender, EventArgs e)
    		{
    			var selectedPerson = PersonList.FirstOrDefault(x => x.FirstName == comboBox.Text);
    			if (selectedPerson == null) return;
     			comboBox.SelectedItem = selectedPerson;
    		}
