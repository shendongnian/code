    string route = "/myroute/{country}/{name}-{type}";
    string input = "/myroute/Denmark/MyName-MyType";
    var routeTemplate = TemplateParser.Parse(route);
    var matcher = new TemplateMatcher(routeTemplate, null);
    var values = new RouteValueDictionary();
    if (matcher.TryMatch(input, values))
    {
        foreach (var item in values)
        {
            Console.WriteLine("{0}: {1}", item.Key, item.Value);
        }
    }
