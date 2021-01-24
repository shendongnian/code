    string natcode = crdv4.smartcardData.NationalityCode.ToString();
    string xmlpath = @"D:\CountriesNameList.xml";
    XDocument xd = XDocument.Load(xmlpath);
    
    string nationality = xd.Descendants("Country")
           .FirstOrDefault(c => c.Attribute("CountryID").Value.Equals(natcode))
           .Attribute("EnglishCountryName").Value;
