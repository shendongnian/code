    //First row
    if (grdMass.RowCount > 0)
    {
        _MSISDN.Append("'");
        _MSISDN.Append(grdMass.Rows[0].Cells[0].Value);
        _MSISDN.AppendLine("'");
    }
    //Second row onwards
    for (int a = 1; a < grdMass.RowCount; a++)
    {
        _MSISDN.Append(",'");
        _MSISDN.Append(grdMass.Rows[a].Cells[0].Value);
        _MSISDN.AppendLine("'");
    }
