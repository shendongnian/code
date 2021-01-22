    public static IEnumerable<SmartForm> GetSmartForms(
           XDocument xmlDoc, Func<XElement,bool> predicate)
        {
            return xmlDoc.Descendants("smartForm")
                .Where(predicate)
                .Select(smartForm => new SmartForm
                {
                    ... snip
                });
        }
