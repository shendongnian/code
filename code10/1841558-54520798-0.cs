    private void AEModalEditor_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!_cancelClicked && !SaveClicked)
        {
            if (CancelModalEditor())
            {
                e.Cancel = true;
            }
            else
            {
                _cancelClicked = true;
                // You called Close here again
                Close();
            }
        }
    }    
