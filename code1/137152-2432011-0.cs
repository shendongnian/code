    int index = 0;
    foreach(HtmlNode tablerow in table.SelectNodes("tr"))
    {
        // skip the first row...
        if(index > 0)
        {
            // select first td element
            HtmlNode td1 = tablerow.SelectSingleNode("td[1]");
            if(td1 != null)
            {
                string address = td1.InnerText;
            }
        }
        index++;
    }
