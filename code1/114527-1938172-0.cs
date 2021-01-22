    for (int a = 0; a < grdMass.RowCount; a++)
    {
        if (a == 0)
        {
            _MSISDN.Append("'");
        }
        else
        {
            _MSISDN.Append(",'");
        }
        _MSISDN.Append(grdMass.Rows[a].Cells[0].Value);
        _MSISDN.AppendLine("'");
    }
