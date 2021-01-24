    CurrenciesDataSet dataset = null;
    var rates = new List<ExchangeRate>();
    XDocument doc = XDocument.Load(@"http://www.bnr.ro/nbrfxrates.xml");
    using (TextReader sr = new StringReader(doc.ToString(SaveOptions.DisableFormatting)))
    {
        var serializer = new XmlSerializer(typeof(CurrenciesDataSet));
        dataset = (CurrenciesDataSet)serializer.Deserialize(sr);
    }
    // According to the schema there might be multiple <Cube> elements,
    // which one do you want??
    Cube cube = dataset.Body.Cubes.FirstOrDefault();
    if (cube != null)
    {
        rates = cube.Rates.Select(x => new ExchangeRate
        {
            DataCurenta = cube.Date,
            Moneda = x.Currency,
            // ....
        }).ToList();
    }
 
