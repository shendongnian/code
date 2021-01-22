    private void timer1_Tick(object sender, EventArgs e)
    {
        timer1.Enabled = false;
        PrintDialog printDialogue=new PrintDocument();        
        //Do your initialising here
        if(DialogResult.OK == printDialogue.ShowDialog())
        {
            //Do your stuff here
        }
    }
