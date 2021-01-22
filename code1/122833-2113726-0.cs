            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Url = new Uri("url_of_file"); //can be remote or local
            webBrowser.DocumentCompleted += delegate
            {
                HtmlElementCollection collection = webBrowser.Document.All;
                List<string> contents = new List<string>();
                /*
                 * Adds all inner-text of a tag, including inner-text of sub-tags
                 * ie. <html><body><a>test</a><b>test 2</b></body></html> would do:
                 * "test test 2" when collection[i] == <html>
                 * "test test 2" when collection[i] == <body>
                 * "test" when collection[i] == <a>
                 * "test 2" when collection[i] == <b>
                 */
                for (int i = 0; i < collection.Count; i++)
                {
                    if (!string.IsNullOrEmpty(collection[i].InnerText))
                    {
                        contents.Add(collection[i].InnerText);
                    }
                }
                
                /*
                 * <html><body><a>test</a><b>test 2</b></body></html>
                 * outputs: test test 2|test test 2|test|test 2
                 */
                string contentString = string.Join("|", contents.ToArray());
                MessageBox.Show(contentString);
            };
