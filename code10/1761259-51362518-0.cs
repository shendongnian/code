    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
           DataGridViewColumn result = dataGridView1.Columns.Cast<DataGridViewColumn>().FirstOrDefault(x => x.Index == 17);
           if(result != null) {
               result.HeaderText = "Failed";
           }
    }
