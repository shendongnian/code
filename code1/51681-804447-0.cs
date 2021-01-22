private void btnDelete_Click(object sender, EventArgs e)
{
  if (grid.CurrentRow == null) return;
  var selectedItem = grid.CurrentRow.DataBoundItem as PartGroup;
  if (selectedItem != null && 
    UIHelper.ShowQuestion("Are you sure you want to delete selected row?") == System.Windows.Forms.DialogResult.Yes)
  {
    groups.Remove(selectedItem);
  }
}
