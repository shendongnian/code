foreach (DataGridViewRow row in dataGridView1.Rows)
{
	if ((string)row.Cells["property_name"].Value == UNKNOWN_PROPERTY_NAME)
	{
		row.DefaultCellStyle.BackColor = Color.LightSalmon;
		row.DefaultCellStyle.SelectionBackColor = Color.Salmon;
	}
}
