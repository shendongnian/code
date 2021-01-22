        private delegate void SetDataSourceDelegate(object value);
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            DataTable oData = null; //'assign data source
            if (dataGridView1.InvokeRequired) {
                dataGridView1.Invoke(new SetDataSourceDelegate(SetDataSource), new Object[] {oData});
            }else{
                SetDataSource(oData); 
            }
        }
        private void SetDataSource(object value) {
            dataGridView1.DataSource = value;
        }
