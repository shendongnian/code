    if (MessageBox.Show("Are you sure you want to quit?", "Attention!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
    {
       //this block will be executed only when Yes is selected
       MessageBox.Show("Data Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    else
    {
      //this block will be executed when No/Cancel is selected
      //the effect of selecting No/Cancel is same in MessageBox (particularly in this event)
    }
