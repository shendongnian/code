    private bool _firstTime = true;
    private void Form1_Activated(object sender, EventArgs e)
    {
       if (_firstTime)
       { 
           _firstTime = false;
           this.Update();
           FetchDataAndOtherTimeSpendingStuffNow();
       }
    }
    
