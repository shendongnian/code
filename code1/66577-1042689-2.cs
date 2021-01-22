    public class BlinkPlugin: IPlugin
    {
    private void MakeTextBlink(string text)
    {
    //code to make text blink.
    }
    public void Run(PluginHost browser)
    {
    MakeTextBlink(browser.CurrentPage.ParsedHtml);
    }
    }
