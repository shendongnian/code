        GeckoElementCollection byTag = _browser.Document.GetElementsByTagName("input");
        foreach (var ele in byTag)
        {
            var input = ele as GeckoInputElement;
            input.Disabled = true;
        }
    etc..
