    private void Form1_Load(object sender, EventArgs e)
    {
        var txt =
        @"<html>" +
        @"<body>" +
        @"<a href=""#"" " +
            @"onclick=""window.external.Method1('Hello');"">" +
            @"Click here.</a>" +
        @"</body>" +
        @"</html>";
        webBrowser1.ObjectForScripting = new ScriptingObject(webBrowser1);
        webBrowser2.ObjectForScripting = new ScriptingObject(webBrowser2);
        webBrowser1.DocumentText = txt;
        webBrowser2.DocumentText = txt;
    }
    [ComVisible(true)]
    public class ScriptingObject
    {
        WebBrowser webBrowser;
        public ScriptingObject(WebBrowser w)
        {
            webBrowser = w;
        }
        public void Method1( string s)
        {
            //This class knows which `WebBrowser` control calls its methods.
            MessageBox.Show(s);
        }
    }
