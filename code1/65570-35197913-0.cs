            private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgv.AutoResizeColumns();
                dgv.AllowUserToResizeColumns = true;
            }
