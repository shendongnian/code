    HtmlPage.RegisterScriptableObject("Page", this);
    ......
    [ScriptableMember]
    public void CallMeInSilverlight(string message)
    {
        HtmlPage.Window.Alert("The form said: " + message);
    }
