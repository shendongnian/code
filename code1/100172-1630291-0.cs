    private void aufgabenDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRow row = aufgabenDataGridView.Rows[e.RowIndex];
      AufgabeStatus status = (AufgabeStatus) Enum.Parse(typeof(AufgabeStatus), (string) row.Cells["StatusColumn"].Value);
      switch (status)
      {
        case (AufgabeStatus.NotStarted):
          e.CellStyle.BackColor = Color.LightCyan;
          break;
        case (AufgabeStatus.InProgress):
          e.CellStyle.BackColor = Color.LemonChiffon;
          break;
        case (AufgabeStatus.Completed):
          e.CellStyle.BackColor = Color.PaleGreen;
          break;
        case (AufgabeStatus.Deferred):
          e.CellStyle.BackColor = Color.LightPink;
          break;
        default:
          e.CellStyle.BackColor = Color.White;
          break;
      }
    }
