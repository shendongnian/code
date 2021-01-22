    public string GetData(int typeOfData)
    {
        XElement container;
        switch (typeOfData)
        {
            case 1:
                // Car->Milage
                container = db.Root.Element("car").Element("mileage");
                break;
            case 2:
                // Car-Fuel
                container = db.Root.Element("car").Element("fuel");
                break;
            default:
                throw new ArugmentOutOfRangeException("typeOfData");
        }
        var results = container.Elements("option")
             .Select(data => new { ID = data.Attribute("value").Value, Name = data.Attribute("text").Value };
    }
