          private void test_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (test.ModifierKeys == Keys.Alt || test.ModifierKeys == Keys.F4) 
              { e.Cancel = true; }
            
        }
