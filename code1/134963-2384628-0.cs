    public class form1 : Form 
    {
      ...
      [DllImport("user32.dll")]
      static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, UIntPtr wParam, IntPtr lParam);
      [DllImport("user32.dll")]
      static extern bool ReleaseCapture(IntPtr hwnd);
      const uint WM_SYSCOMMAND = 0x112;
      const uint MOUSE_MOVE = 0xF012;      
      public void DragMe()
      {
         DefWindowProc(this.Handle, WM_SYSCOMMAND, (UIntPtr)MOUSE_MOVE, IntPtr.Zero);
      }
      private void button1_MouseDown(object sender, MouseEventArgs e)
      {
         Control ctl = sender as Control;
         // when we get a buttondown message from a button control
         // the button has capture, we need to release capture so
         // or DragMe() won't work.
         ReleaseCapture(ctl.Handle);
         this.DragMe(); // put the form into mousedrag mode.
      }
