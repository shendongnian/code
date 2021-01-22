    string[] s = websitePages.Select((websitePage, i) =>
            String.Format("<li{0}><a href=\"{1}\">{2}</a></li>\n",
                          i == 0 ? " class=\"first\"" : "",
                          websitePage.GetFileName(),
                          websitePage.Title)).ToArray();
    string result = string.Join("", s);
