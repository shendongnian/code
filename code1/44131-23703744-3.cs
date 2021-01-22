    private void TextBoxKeyPressEvent(object sender, KeyPressEventArgs e)
            {
                string prevText;
                bool wasBackspaced = false;
    
                // The following logic will either add or remove a character to/from the text string depending if the user typed
                // an additional character or pressed the Backspace key.  At the end of the day, the cell will (at least) be
                // sized to the configured minimum column width or the largest row width in the column because we're using 
                // AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells.
                if (e.KeyChar == Convert.ToChar(Keys.Back))
                {
                    prevText = dataGridView1.CurrentCell.EditedFormattedValue.ToString();
    
                    if (prevText.Length == 0)
                    {
                        // Don't try to make it any smaller...
                        return;
                    }
    
                    // Remove an arbitrary character for determining appropriate measurements.
                    prevText = prevText.Remove(prevText.Length - 1);
                    wasBackspaced = true;
                }
                else
                {
                    // Gets the text prior to the new character being added.  Appending an arbitrary "0" to the value
                    // to account for the missing character when determining appropriate measurements.
                    prevText = dataGridView1.CurrentCell.EditedFormattedValue.ToString() + "0";
                }
    
                Graphics editControlGraphics = dataGridView1.EditingControl.CreateGraphics();
    
                // Gets the length of the current text value.
                SizeF stringSize = editControlGraphics.MeasureString(prevText, dataGridView1.EditingControl.Font);
    
                int widthForString = (int)Math.Round(stringSize.Width, 0);
    
                // Makes the column width big, or small, enough if it's not already.
                if (dataGridView1.CurrentCell.OwningColumn.Width < widthForString ||  // 1. Applies when adding text
                    (dataGridView1.CurrentCell.OwningColumn.Width > widthForString &&          // ---
                     dataGridView1.CurrentCell.OwningColumn.MinimumWidth < widthForString &&   // 2. Applies when backspacing
                     wasBackspaced))                                                           // ---
                {
                    dataGridView1.CurrentCell.OwningColumn.Width = widthForString;
                }
            }
