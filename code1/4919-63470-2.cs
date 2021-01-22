        /// <summary>
        /// Recursively traverse a tree of controls to find the control that has focus, if any
        /// </summary>
        /// <param name="c">The control to search, might be a control container</param>
        /// <returns>The control that either has focus or contains the control that has focus</returns>
        private Control FindFocus(Control c) 
        {
            foreach (Control k in c.Controls)
            {
                if (k.Focused)
                {
                    return k;
                }
                else if (k.ContainsFocus)
                {
                    return FindFocus(k);
                }
            }
            return null;
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            // Find the control that has focus
            Control focusedControl = FindFocus(f.ActiveControl);
            // See if focusedControl is of a type that can select text/data
            if (focusedControl is TextBox)
            {
                TextBox tb = focusedControl as TextBox;
                Clipboard.SetDataObject(tb.SelectedText);
            }
            else if (focusedControl is DataGridView)
            {
                DataGridView dgv = focusedControl  as DataGridView;
                Clipboard.SetDataObject(dgv.GetClipboardContent());
            }
            else if (...more?...)
            {
            }
        }
        
