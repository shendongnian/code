    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_PASTE)
        {
            string clipboardVin = Clipboard.GetText();
            string newVin = "";
            if (SelectionLength > 0)
            {
                newVin = Text.Replace(SelectedText, "");
            }
            else
            {
                newVin = Text;
            }
            newVin = newVin.Insert(SelectionStart, clipboardVin);
            if (!vinRegEx.IsMatch(newVin))
            {
                m.Result = new IntPtr(Convert.ToInt32(true));
                MessageBox.Show("The resulting text is not a valid VIN.", "Can Not Paste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        else
        {
            base.WndProc(ref m);
        }
    }
