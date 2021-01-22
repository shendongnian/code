        // ---------------------------------------------------------------------------
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Copies the original column width because switching to DataGridViewAutoSizeColumnMode.None
            // will automatically make the column a default width.
            int origColumnWidth = dataGridView1.Columns[e.ColumnIndex].Width;
            dataGridView1.Columns[e.ColumnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            // Reverts back to the original width.
            dataGridView1.Columns[e.ColumnIndex].Width = origColumnWidth;
        }
        // ---------------------------------------------------------------------------
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns[e.ColumnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        // ---------------------------------------------------------------------------
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                var tbox = (e.Control as TextBox);
                // De-register the event FIRST so as to avoid multiple assignments (necessary to do this or the event
                // will be called +1 more time each time it's called).
                tbox.KeyPress -= TextBoxKeyPressEvent;
                tbox.KeyPress += TextBoxKeyPressEvent;
            }
        }
        // ---------------------------------------------------------------------------
        private void TextBoxKeyPressEvent(object sender, KeyPressEventArgs e)
        {
            // Gets the text prior to the new character being added.  Appending an arbitrary "0" to the value
            // to account for the missing character when determining appropriate measurements.
            string prevText = dataGridView1.CurrentCell.EditedFormattedValue.ToString() + "0";
            Graphics editControlGraphics = dataGridView1.EditingControl.CreateGraphics();
            // Gets the length of the current text value.
            SizeF stringSize = editControlGraphics.MeasureString(prevText, dataGridView1.EditingControl.Font);
            int widthForString = (int)Math.Round(stringSize.Width, 0);
            // Makes the column width big enough if it's not already.
            if (dataGridView1.CurrentCell.OwningColumn.Width < widthForString)
            {
                dataGridView1.CurrentCell.OwningColumn.Width = widthForString;
            }
        }
