Taking advantage of DataGridViewCell's events CellEnter and CellLeave you might try something like this:
    private void foobarDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
      DataGridViewCellStyle fooCellStyle = new DataGridViewCellStyle();
      fooCellStyle.BackColor = System.Drawing.Color.LightYellow;
      this.VariableFinderDataGridView.CurrentCell.Style.ApplyStyle(fooCellStyle);
    }
    private void foobarFinderDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
    {
      DataGridViewCellStyle barCellStyle = new DataGridViewCellStyle();
      barCellStyle.BackColor = System.Drawing.Color.White;
      this.VariableFinderDataGridView.CurrentCell.Style.ApplyStyle(barCellStyle);
    }
