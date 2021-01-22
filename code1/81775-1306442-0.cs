    using (SqlCommand command = new SqlCommand(
       "SELECT stammDatenId, position, latitude, longitude "+
       "FROM geoKoordinates ORDER BY stammDatenId, position", connection))
    {
        using (IDataReader reader = command.ExecuteReader())
        {
            // ...
        }
    }
