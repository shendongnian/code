    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Key.A)
        {
            if(!timer1.Enabled)
    			timer1.Start();
    		else
    			timer1.Stop();
    			
        }
    }
