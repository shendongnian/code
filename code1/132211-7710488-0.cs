    private void btnBottomToTop_Click(object sender, System.EventArgs e)
        {
          flags = WinAPI.AW_HIDE | WinAPI.AW_VER_NEGATIVE| WinAPI.AW_SLIDE;    
          WinAPI.AnimateWindow(we.Handle,1000,flags);
          frm.Show();
        }
