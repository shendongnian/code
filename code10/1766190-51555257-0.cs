    City ConvertToCity(DataRow row)
    {
        return new City
        {
            CityCode = row.Field<object>("CITY_CODE"),
            CityMid = row.Field<object>("CITY_MID"),
            CityName = row.Field<object>("CITY_NAME"),
            CountryCode = row.Field<object>("COUNTRY_CODE"),
            StateCode = row.Field<object>("STATE_CODE"),
            ActiveFlag = row.Field<object>("ACTIVE_FLG"),
        };
    }
