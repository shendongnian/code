     private void Form1_VisibleChanged(object sender, EventArgs e)
     {
                if (_isClosing)
                {
    
                }
                else
                {
                    // Code when form is shown
                }
    
                _isClosing = false;
        }
    
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                _isClosing = true;
                e.Cancel = true;
                Hide();
        }
