    protected override void WndProc(ref Message m)
    {
        //0x210 is WM_PARENTNOTIFY
        if (m.Msg == 0x210 && m.WParam.ToInt32() == 513) //513 is WM_LBUTTONCLICK
        {
            Console.WriteLine(m); //You have a mouseclick(left)on the underlying user control
        }
        base.WndProc(ref m);
    }
