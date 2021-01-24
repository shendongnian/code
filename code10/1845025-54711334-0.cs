    public void LoadData(IList conTable)
        {
            var mtc = new MisTableConversions();
            dgvDetailedTable.DataSource = null; 
            dgvDetailedTable.DataSource = mtc.ToSortableBindingList(conTable);
            dgvDetailedTable.RowTemplate.Height = UiConsts.RowHeight;
            // Use sorting here
            this.DgvDetailedTable.Sort(this.DgvDetailedTable.Columns["Name"], ListSortDirection.Ascending);
        }
