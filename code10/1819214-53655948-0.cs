    using System.Linq;
    
    if (MessageBox.Show("...", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
    int selectedPersonId = dgcontact.SelectedCells.Cast<DataGridViewCell>()
                    .Where(cell => cell.OwningColumn.Index.Equals(1))
                    .Select(cell => Convert.ToInt32(cell.Value)).First();
    repository.delete(selectedPersonId);
    }
