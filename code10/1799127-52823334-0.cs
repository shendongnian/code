    //in your code that handles loading the grid with data, e.g. in a Load button handler
      patientListTableAdapter.Fill(ds.PatientList); //strongly typed dataset, table is already bound to grid in design time
    private void TB_FirstName_TextChanged(object sender, EventArgs e){
      if(string.IsNullOrWhiteSpace(TB_FirstName.Text)
        patientListBindingSource.Filter = null;
      else
        patientListBindingSource.Filter = string.Format("NAM LIKE '%{0}%'", TB_FirstName.Text);
    }
