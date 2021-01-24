    private const int APPCOMMAND_MEDIA_PLAY_PAUSE = 14;
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        switch (m.Msg)
        {
            case (int)WinApi.WinMessage.WM_APPCOMMAND:
                int cmd = (int)m.LParam >> 16;
                switch (cmd)
                {
                    case APPCOMMAND_MEDIA_PLAY_PAUSE:
                        TogglePlayPause();
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
