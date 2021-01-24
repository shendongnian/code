                string uri = "http://bc.rcmp-grc.gc.ca/ViewPage.action?siteNodeId=2087&languageId=1&contentId=57000";
                var web = new HtmlWeb();
                web.UseCookies = true;
                var doc = web.Load(uri);
                IEnumerable<HtmlParseError> d = doc.ParseErrors; // 6 errors, but so what
          
                if ( (web.StatusCode != HttpStatusCode.OK))
                {
                //    return string.Empty;
                }
                else
                {
                   // works for me:
                   var bodyInnerhtml = doc.DocumentNode.SelectNodes("//body")[0].InnerHtml;                            
                }
