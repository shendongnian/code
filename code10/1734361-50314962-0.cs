     geckoWebBrowser1.Navigate("google.com");
            GeckoHtmlElement element = null;
            var geckoDomElement = geckoWebBrowser1.Document.DocumentElement;
            if (geckoDomElement is GeckoHtmlElement)
            {
                element = (GeckoHtmlElement)geckoDomElement;
                var innerHtml = element.InnerHtml;
                
                using (FileStream fs = new FileStream(@"" + "aaa" + ".html", FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.WriteLine(innerHtml);
                    }
                }
            }
