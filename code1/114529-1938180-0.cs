     if (grdMass.RowCount > 0)
     {
          _MSISDN.AppendLine("'" + grdMass.Rows[0].Cells[0].Value.ToString() + "'");
          for (int a = 1; a < grdMass.RowCount; a++)
          {
                _MSISDN.AppendLine(",'" + grdMass.Rows[a].Cells[0].Value.ToString() + "'");
          }     
     }
