    private SomeObject = selectedSomeObject=null;
    private void cbxTemplates_SelectionChangeCommitted(object sender, EventArgs e)
    {
      if (!(sender is ComboBox cb)) return;
      if (!(cb.SelectedItem is SomeObject tem)) return;
      if (MessageBox.Show("You sure?", "??.",
            MessageBoxButtons.OKCancel) != DialogResult.OK)
        cb.SelectedItem = selectedSomeObject;
      else
      {
        selectedSomeObject = tem;
      }
    }
