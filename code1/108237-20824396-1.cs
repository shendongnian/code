    public static class EnumHelper
    {
        public static string EnumDisplayName(this HtmlHelper helper,EPriceType priceType)
        {
            //Get every fields from enum
            var fields = priceType.GetType().GetFields();
            //Foreach field skipping 1`st fieldw which keeps currently sellected value
            for (int i = 0; i < fields.Length;i++ )
            {
                //find field with same int value
                if ((int)fields[i].GetValue(priceType) == (int)priceType)
                {
                    //get attributes of found field
                    var attributes = fields[i].GetCustomAttributes(false);
                    if (attributes.Length > 0)
                    {
                        //return name of found attribute
                        var retAttr = (EnumDisplayName)attributes[0];
                        return retAttr.Name;
                    }
                }
            }
            //throw Error if not found
            throw new Exception("Błąd podczas ustalania atrybutów dla typu ceny allegro");
        }
    }
