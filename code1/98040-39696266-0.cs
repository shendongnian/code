    protected override void OnMouseDown(MouseEventArgs e)  
    {
          base.OnMouseDown(e);
          if (e.Button == MouseButtons.Left)
          {
            this.Capture = false;
            Message msg = Message.Create(this.Handle, 0XA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref msg);
          }
    }
