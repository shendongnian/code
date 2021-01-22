    public static string GetAllText(WebBrowser webBrowser)
    {
                webBrowser.Focus();
                SendKeys.Send("^{a}");
                SendKeys.Send("^{c}");
                return ClipBoard.GetText();
    }
