    private void DataGridViewCompleteRefresh()
            {
                dataGridView.DataSource = null;
                Thread.Sleep(100);
                dataGridView.DataSource = data.table;
                dataGridView.Columns["Site Origin"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns["Year"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns["Bitrate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns["Release Format"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns["Bit Format"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns["Handled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns["Error"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns["File Path"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Update();
                dataGridView.Refresh();
            }
