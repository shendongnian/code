    private void box_MouseDown(object sender, MouseEventArgs e)
    {
          if (e.Button == MouseButtons.Left)
          {
             TimeSpan Current = DateTime.Now - LastClick;
             TimeSpan DblClickSpan =
             TimeSpan.FromMilliseconds(SystemInformation.DoubleClickTime);
    
             if (Current.TotalMilliseconds <= DblClickSpan.TotalMilliseconds)
             {
         // Code to handle double click goes here
             }
    
             LastClick = DateTime.Now;
          }
    }
