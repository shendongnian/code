    TextBlock messageBar;
    ScrollViewer messageScroller; 
    
        private void displayMessage(string message)
        {
                   
                    messageBar.Text += message + "\n";
                 
                    double pos = this.messageScroller.ExtentHeight;
                    messageScroller.ChangeView(null, pos, null);
        } 
