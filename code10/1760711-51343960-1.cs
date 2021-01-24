    private void button3_Click(object sender, EventArgs e)
    {
        var links = webBrowser1.Document.GetElementsByTagName("div");
        foreach (HtmlElement link in links)
        {
            if (link.GetAttribute("title").Equals("div_name"))
            {
                HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = webBrowser1.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
                element.text = "function clickTitle() { document.getElementById('" + link.GetAttribute("id") + "').click(); }";
                head.AppendChild(scriptEl);
                webBrowser1.Document.InvokeScript("clickTitle");
            }
        }
    }
    
