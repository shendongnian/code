    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x216)  // WM_MOVING = 0x216
        {
            Rectangle rect = 
               (Rectangle) Marshal.PtrToStructure(m.LParam, typeof (Rectangle));
            if (rect.Left < 100)
            {
                rect.Location = new Point(100, rect.Location.Y);
                Marshal.StructureToPtr(rect, m.LParam, true);
            }
        }
        base.WndProc(ref m);
    }
