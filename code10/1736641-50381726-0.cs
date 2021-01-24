    Commodities commodities = null;
    using (var stream = new StringReader(xmlString))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Commodities));
        commodities = (Commodities) serializer.Deserialize(stream);
    }
    var commodityName = "corn";
    var platformName = "bloomberg";
    var year = "2018";
    var commodity = commodities.Grains.Commodity.Single(c => c.Name.Equals(commodityName, StringComparison.InvariantCultureIgnoreCase));
    var symbol = commodity.Specs.SymbolRoot.Platform.Single(p => p.Name.Equals(platformName, StringComparison.InvariantCultureIgnoreCase));
    var months = commodity.ContractMonths.Month.Year.Where(y => y.Value.Equals(year, StringComparison.InvariantCultureIgnoreCase));
