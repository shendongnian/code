    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if(rb1.Checked == true){ //if someone just checked that radio button
                resetAllButtons(); //resetting all checkbox buttons as you wanted
                cb2.Enabled = false; //making checkbox2 unclickable
                cb3.Enabled = false; //making checkbox3 unclickable
                cb4.Enabled = false; //making checkbox3 unclickable
                /* and so on */
        }
    }
