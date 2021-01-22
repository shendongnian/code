    public class Nav
    {
        FormNav formNav = new FormNav();
        public string Source
        {
            get
            {
                mshtml.HTMLDocument doc = (mshtml.HTMLDocument)formNav.webBrowser.Document.DomDocument;
                return doc.documentElement.innerHTML;
            }
        }
        public void GoTo(string Url)
        {
            formNav.webBrowser.Navigate(Url);
            Wait();
        }
        public void Fill(string Field, string Value)
        {
            formNav.webBrowser.Document.GetElementById(Field).InnerText = Value;
        }
        public void Click(string Element)
        {
            formNav.webBrowser.Document.GetElementById(Element).InvokeMember("click");
            Wait();
            Application.DoEvents();
        }
        public void Wait()
        {
            const int TIMEOUT = 30;
            formNav.Ready = false;
            DateTime start = DateTime.Now;
            TimeSpan span;
            do
            {
                Application.DoEvents();
                span = DateTime.Now.Subtract(start);
            } while (!formNav.Ready && span.Seconds < TIMEOUT);
        }
        public void Dispose()
        {
            formNav.Dispose();
        }
    }
