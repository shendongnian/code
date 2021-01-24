    var result = MessageBox.Show("Are you sure you want to exit", "", MessageBoxButtons.YesNoCancel);
    switch(result)
    {
        case DialogResult.Yes:
            //Another box pops up to ask the user why
            MessageBox.Show("Why?!", "", MessageBoxButtons.RetryCancel);
            Application.Restart();
            break;
        case DialogResult.No:
            //Informational box
            MessageBox.Show("OK ^_^! Good Luck!", "", MessageBoxButtons.OK);
            Application.Restart();
        default:
            //Assume Cancel to be the default behavior, 
            //Pick any value to be the default. It's up to you.
            //Make sure they really, REALLY want to cancel
            if (MessageBox.Show("Are you sure you want to cancel?", "", MessageBoxButtons.OKCancel) == DialogResult.OK) 
            {
                MessageBox.Show("Ok! Good Luck!");
                Application.Restart();
            } 
            else 
            {
                MessageBox.Show("Error!");
                Application.Restart();
            }
    }
