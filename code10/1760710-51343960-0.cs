    private void button3_Click(object sender, EventArgs e)
    {
        var links = webBrowser1.Document.GetElementsByTagName("div");
        foreach (HtmlElement link in links)
        {
            if (link.GetAttribute("title").Equals("div_name"))
            {
                //link.InvokeMember("click");
                link.SetAttribute("onclick","javascript:window.alert('Hello World');");
                return;
            }
        }
    }
