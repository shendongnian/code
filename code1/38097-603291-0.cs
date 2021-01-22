    public class myCustomTextBox : TextBox
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 770) // window paste message id
            {
                string clipBoardData = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
                handlePasteEvent(clipBoardData);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        private void handlePasteEvent(string pasteData)
        {
            // process pasted data
        }
    }
