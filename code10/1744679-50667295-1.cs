        private static readonly XNamespace googleNs = "http://base.google.com/ns/1.0";
        private static readonly XName idName = googleNs + "id";
        private static readonly XName availabilityName = googleNs + "availability";
    and then
        if (el.Name == idName)
        {
            prod.SKU = el.Value.Replace("-master", string.Empty);
        }
        else if (el.Name == availabilityName)
        {
            prod.Availability = el.Value == "in stock";
        }
