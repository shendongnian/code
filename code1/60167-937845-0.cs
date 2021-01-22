        WM_CLOSE = 0x0010
    
        protected override void WndProc(ref Message m)
        {
          if(m.Msg == WM_CLOSE)
          {
            this.Hide();
            trayIcon.Show();
          }
        
        }
