    private bool WeAreDone = false;
    
    private void DoingIt()
    {
        while (true)
        {
            Application.DoEvents();
            if (WeAreDone)
            {
                break;
            }
        }
    }
    
    private void InterruptButton_Click(object sender, EventArgs e)
    {
        WeAreDone = true;
    }
