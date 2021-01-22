    if (m.Msg == 0x0084) {              //WM_NCHITTEST
        var point = new Point((int)m.LParam);
        if(someRect.Contains(PointToClient(point))
            m.Result = new IntPtr(2);   //HT_CAPTION
    }
