    private const Int32 WM_User = 0x400;
    private const Int32 EM_SETEDITSTYLEEX = WM_User + 275;
    private const Int32 EM_GETEDITSTYLEEX = WM_User + 276;
    
    /// <summary>Display friendly name links with the same text color and underlining as automatic links, provided that temporary formatting isn’t used or uses text autocolor (default: 0)</summary>
    private const Int32 SES_EX_HANDLEFRIENDLYURL = 0x100;
    
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private extern static Int32 SendMessage(HandleRef hWnd, Int32 msg, Int32 wParam, Int32 lParam);
    
    public static void UnderlineFriendlyLink(RichTextBox rtb, bool enabled = false)
    {
        if (rtb.IsHandleCreated)
        {
            Int32 wParam = enabled ? SES_EX_HANDLEFRIENDLYURL : 0;
            Int32 lParam = SES_EX_HANDLEFRIENDLYURL; // settings mask
            Int32 res = SendMessage(new HandleRef(null, rtb.Handle), EM_SETEDITSTYLEEX, wParam, lParam);
        }
    }
