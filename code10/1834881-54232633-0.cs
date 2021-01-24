    var model = new List<CountryModel>();
    foreach (var item in Enum.GetValues(typeof(CountryListEnum)))
    {
        model.Add(new CountryModel
        {
            CountryId = (int)item,
            CountryName = ((DescriptionAttribute[])item.GetType().GetField(item.ToString()).GetCustomAttributes(typeof(DescriptionAttribute)))[0].Description
        });
    }
