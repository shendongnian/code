    public property fillPropertyBySource(IProperty source)
    {
        property prop = new property();
        if (source is Residential)
        {
            Residential o = (Residential)source;
            //Fill Residential only fields
        }
        else if (source is Commercial)
        {
            Commercial o = (Commercial)source;
            //Fill Commercial only fields
        }
        //Fill fields shared by both
        prop.price = source.price;
        prop.bathrooms = source.bathrooms;
        return prop;
    }
