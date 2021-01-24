    class ParserWorker
    {
        public void WorkerHTMLFile()
        {
            for (int i = 0; i <= ListUrlActive.Count; i++)
            {
                string source = File.ReadAllText(ListUrlActive[i]);
                ParsingPage(source);
            }
        }
        public async void ParsingPage(string source)
        {
            var domParser = new HtmlParser();
            IHtmlDocument document = await domParser.ParseAsync(source);
            siteParser.Parsing(document);
        }
    }
    public class SiteParser
    {
        public async void Parsing(IHtmlDocument document)
        {
            switch (settingOper.objectParsing)
            {
                case "Type_1":
                    /// ...
                    /// ... Code
                    /// ...
                    break;
                case "Type_2":
                    var domParserAnnounc = new HtmlParser();
                    var htmlBlockAnnounc = document.QuerySelectorAll("div.flexRoot > div.view.main");
                    foreach (var item in htmlBlockAnnounc)
                    {
                        string s = item.OuterHtml;
                        IHtmlDocument documentCur = await domParserAnnounc.ParseAsync(s);
                        await ParsingPoster(documentCur);
                    }
                    break;
            }
        }
    }
    public async void ParsingPoster(IHtmlDocument document)
    {
        try
        {
            try
            {
                settingOper.email = document.QuerySelectorAll("#start_widget > div:nth-child(3) > div.form-line.view-form-line > div.adv-point.view-adv-point > script:nth-child(3)")[0].TextContent.Trim();
                if (settingOper.email == null)
                {
                    settingOper.email = document.QuerySelectorAll("div[class='adv-point view-adv-point']>script[type*='text/javascript']")[0].TextContent.Trim();
                }
                settingOper.email = wordProcessing.FindRegularExpression(settingOper.email, @"(?<=eval\(unescape\(').*(?='\)\))");
                settingOper.email = wordProcessing.DecodeResult(settingOper.email);
                IHtmlDocument htmlDocumentEmail = await domParser.ParseAsync(settingOper.email);
                var itemsAttr = htmlDocumentEmail.QuerySelectorAll("a");
                settingOper.email = itemsAttr[0].TextContent.Trim();
            }
            catch (Exception ex)
            {
                InfoMessageErrorEvent?.Invoke("Поле: 'email'. Error !!!" + ex.Message);
            }
        }
        catch (Exception ex)
        {
            string s1 = ex.Message;
            string s2 = ex.StackTrace;
            // throw;
        }
    }
