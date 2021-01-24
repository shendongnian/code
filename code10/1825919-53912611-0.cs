    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class OAKListView : ListView
        {
          protected override void OnHandleCreated(EventArgs e)
              {
                    base.OnHandleCreated(e);
                    var message = new Message()
                    {
                        HWnd = this.Handle,
                        Msg = 4150,
                        LParam = (IntPtr)43,
                        WParam = IntPtr.Zero
                    };
                    this.WndProc(ref message);
                }
            }
