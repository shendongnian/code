        WebBrowser client = new WebBrowser();
        try
        {
            HtmlDocument doc = await client.LoadSiteAndGetHtml(url);
        }
        catch (WebException)
        {
            if (MessageBox.Show(text: "WebException", caption: "Hata", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error) == DialogResult.OK)
            {
            }
        }
