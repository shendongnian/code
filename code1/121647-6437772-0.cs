    private bool mSingleClick;
    
    private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
    {
            
        if (e.Button == MouseButtons.Left)
        {
            if (e.ClickCount < 2)
            {
                mSingleClick = true;
                clickTimer.Interval = System.Windows.Forms.SystemInformation.DoubleClickTime;
                clickTimer.Start();
            }
            else if (e.ClickCount == 2)
            {
                clickTimer.Stop();
                mSingleClick = false;
                MessageBox.Show("you double-clicked");
            }
        }
    }
    private void clickTimer_Tick(object sender, EventArgs e)
    {
        if (mSingleClick)
        {
            clickTimer.Stop();
            mSingleClick = false;
            MessageBox.Show("you single-clicked");
        }
    }
