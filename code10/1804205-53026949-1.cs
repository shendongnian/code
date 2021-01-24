    private const int WM_APPCOMMAND = 0x0319;
    private const int APPCOMMAND_MEDIA_PLAY_PAUSE = 14;
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        switch (m.Msg)
        {
            case WM_APPCOMMAND:
                int cmd = (int)m.LParam >> 16 & 0xFF;
                switch (cmd)
                {
                    case APPCOMMAND_MEDIA_PLAY_PAUSE:
                        TogglePlayPause();
                        break;
                    default:
                        break;
                }
                m.Result = (IntPtr)1;
                break;
            default:
                break;
        }
    }
