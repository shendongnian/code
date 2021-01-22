    using System.Runtime.InteropServices;
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x216)  // WM_MOVING = 0x216
        {
            Rectangle rect = 
               (Rectangle) Marshal.PtrToStructure(m.LParam, typeof (Rectangle));
            if (rect.Left < 100)
            {
                // compensates for right side drift
                rect.Width = rect.Width + (100 - rect.Left);
                // force left side to 100
                rect.X = 100;
                Marshal.StructureToPtr(rect, m.LParam, true);
            }
        }
        base.WndProc(ref m);
    }
