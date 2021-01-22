         private void grid_CellParsing(object sender, DataGridViewCellParsingEventArgs e) {
            string val = e.Value.ToString();
            DataGridViewCell cell = this.dgvGroup1[e.ColumnIndex, e.RowIndex];
            if (e.DesiredType == typeof(GridValueGroup))
            {
                ((GridValueGroup)cell.Value).ObjValue = val;
                e.Value = ((GridValueGroup)cell.Value);
            }
            e.ParsingApplied = true;
   
        }
