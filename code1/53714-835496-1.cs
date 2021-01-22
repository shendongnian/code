      private bool IsChild(System.Windows.Forms.Control control, System.IntPtr hWnd)
      {
         if(control.Handle == hWnd)
            return(true);
         foreach (System.Windows.Forms.Control child in control.Controls)
         {
            if (IsChild(child, hWnd))
               return (true);
         }
         return (false);
      }
