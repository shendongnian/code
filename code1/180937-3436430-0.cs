       foreach (HtmlElement item in webBrowser1.Document.GetElementsByTagName("li"))
            {
                // use contains() if the class attribute is 
                // class="page_item page-item-218 current_page_item"
                //this to be more on spot! >> if (item.OuterHtml.Contains("class=\"page_item"))
                // or
                if (item.OuterHtml.Contains("page_item"))
                {
                    foreach (HtmlElement childItem in item.Children)
                    {
                        if (childItem.TagName.ToLower() == "a")
                        {
                            //Click the link/Current element
                            childItem.InvokeMember("Click");
                            break;
                        }
                    }
                    break;
                }
            } 
