    private void AlbumChecker_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab)
        {
            SelectNextEditableCell(DataGridView dataGridView);
        }
    }
