    class Program
    {
        static void Main(string[] args)
        {
            var response = getHtml("http://www.bbc.com");
            var html = response.Result;
            HtmlParser htmlParser = new HtmlParser();
            var parsedDoc = htmlParser.Parse(html);
            var body = parsedDoc.Body;
            var elements = getAllElements(parsedDoc.Body);
            for(var i = 0; i < elements.Count; i++)
            {
                var child = elements[i];
                child.SetAttribute("data-id", $"data-id{i + 1}");
            }
            File.WriteAllText("E:/soQuestion.txt", parsedDoc.Body.InnerHtml);
        }
        static async Task<string> getHtml(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                //if http request did not succeeed, return empty html
                if (!response.IsSuccessStatusCode) return string.Empty;
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }
        static List<IElement> getAllElements(IElement element)
        {
            List<IElement> elements = new List<IElement>();
            
            //add element itself
            elements.Add(element);
            foreach (var child in element.Children)
            {
                //add each child elements
                elements.AddRange(getAllElements(child));
            }
            return elements;
        }
    }
