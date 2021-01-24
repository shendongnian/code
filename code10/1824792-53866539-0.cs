        DateTime searchDate = DateTime.Now.AddDays(-days);
        oracleShipments = oracleEntities.Shipments.Where(s => consignorCodes.Contains(s.CONSIGNOR))
                                                  .AsEnumerable()
                                                  .Where(s=> s.UNLOADINGTIMEEND.CompareTo(searchDate) > 0)
                                                  .ToList();
