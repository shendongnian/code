    private void Form_FormClosing(object sender, FormClosingEventArgs e)
    {
        switch (e.CloseReason)
        {
            case CloseReason.UserClosing:
                switch (this.DialogResult)
                {
                    case DialogResult.OK:
                        // User has clicked button.
                        break;
                    case DialogResult.Cancel:
                        // User has clicked X on form, show your yes/no/cancel box here.
                        // Set cancel here to prevent the closing.
                        //e.Cancel = true;
                        break;
                }
                break;
        }
    }
