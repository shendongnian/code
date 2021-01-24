    dt.Columns.AddRange(new DataColumn[2]{ new DataColumn("CharacteristicName", typeof(string)), 
                        new DataColumn("MaxNoPlaces", typeof(int))});
    
    foreach (DataRow dr in dtKar.Rows)
    {
        // perform integer conversion
        dt.Rows.Add(dr["CharacteristicName"].ToString(), Convert.ToInt32(dr["MaxNoPlaces"]));
    }
