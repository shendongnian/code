    void Find_Element()
        {
            string x1 = "<div";
            string x2 = "btnA";
            var ele = ElementBrowser.Document.GetElementsByTagName("div");
            foreach (HtmlElement link in ele)
            {
                string item = link.OuterHtml.ToString().Trim();
                if (item.StartsWith(x1) && item.Contains(x2))
                {
                    link.InvokeMember("click");
                }
            }
        }
