    foreach (DataColumn dc in dt.Columns)
    {
      if (dc.DataType == typeof(DateTime))
      {
        dc.DateTimeMode = dateMode;
      }
    }
    SetAllDateModes(dt, DataSetDateTime.Unspecified);
