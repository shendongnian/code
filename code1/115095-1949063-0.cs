       protected override void WndProc(ref Message m)
       {
           const int WM_NCRBUTTONDOWN = 0xA4;
           if (m.Msg == WM_NCRBUTTONDOWN)
           {
               MessageBox.Show("Caption right clicked!");
           }
           else
           {
               base.WndProc(ref m);
           }
       }
