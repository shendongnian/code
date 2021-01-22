CheckBox checkboxHeader = null;
bool isHeaderCheckBoxClicked = false;
private void AddChkBoxHeader_DataGridView()
{
    Rectangle rect = dgvRecipeSelector.GetCellDisplayRectangle(0, -1, true);
    rect.Y = 10;
    rect.X = rect.Location.X + (rect.Width / 4);            
    checkboxHeader = new CheckBox();
    checkboxHeader.Size = new Size(15,15);
    checkboxHeader.Location = rect.Location;
    dgvRecipeSelector.Controls.Add(checkboxHeader);
    checkboxHeader.MouseClick += new MouseEventHandler(checkboxHeader_CheckedChanged);
}
private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
{            
    HeaderCheckBoxClick((CheckBox)sender);
}
private void HeaderCheckBoxClick(CheckBox headerCheckbox)
{
    isHeaderCheckBoxClicked = true;
    foreach (DataGridViewRow r in dgvRecipeSelector.Rows)
    {
        ((DataGridViewCheckBoxCell)r.Cells[0]).Value = headerCheckbox.Checked;
    }
    dgvRecipeSelector.RefreshEdit();
    isHeaderCheckBoxClicked = false;
}
