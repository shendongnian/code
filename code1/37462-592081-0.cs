    XXX.manageMainMenuButtons(utmToolBar, string.IsNullOrEmpty(rtbSharedSARP.Text));
    public static void manageMainMenuButtons(Object /*whatever utmToolBar actually is*/ utmToolBar, bool disable)
    {
        utmToolBar.Tools["First"].SharedProps.Enabled = disable;
        utmToolBar.Tools["Previous"].SharedProps.Enabled = disable;
        utmToolBar.Tools["Next"].SharedProps.Enabled = disable;
        utmToolBar.Tools["Last"].SharedProps.Enabled = disable;
    }
