        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICopyPasteable control = sender as ICopyPasteable;
            if (control != null)
            {
                control.CopyToClipboard();
            }
        }
    
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICopyPasteable control = sender as ICopyPasteable;
            if (control != null)
            {
                control.PasteFromClipboard();
            }
        }
    }
    
    
    public interface ICopyPasteable
    {
        void CopyToClipboard();
        void PasteFromClipboard();
    }
    
    public class MyTextBox : TextBox, ICopyPasteable
    {
    
        #region ICopyPasteable Membres
    
        public void CopyToClipboard()
        {
            Clipboard.SetText(this.Text);
        }
    
        public void PasteFromClipboard()
        {
            if (Clipboard.ContainsText())
            {
                this.Text = Clipboard.GetText();
            }
        }
    
        #endregion
    }
