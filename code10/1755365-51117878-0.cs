        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pasteText = Clipboard.GetText(TextDataFormat.Text).ToString();
            if (Clipboard.ContainsText())
            {
                var start = rtbNotePad.SelectionStart; // use this if you want to keep cursor where it was
                //start += pasteText.Length;    // use this if want to move cursor to the end of pasted text
                rtbNotePad.Text = rtbNotePad.Text.Insert(rtbNotePad.SelectionStart, Clipboard.GetText(TextDataFormat.Text).ToString());
                rtbNotePad.SelectionStart = start;
               // rtbNotePad.Focus();
            }
        }
