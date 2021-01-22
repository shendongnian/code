    public void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
            {
                    libDataGrid.DataSource = this.manager.Lib.LibList;
                    libDataGrid.Refresh();
            }
