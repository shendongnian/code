            // RouteValueDictionary is IDictionary<string, object>
            var dictionary = new RouteValueDictionary();  
            string s = "cool";
            dictionary.Add(s, 123);
            htmlHelper.ActionLink("Home", "Index", dictionary);
