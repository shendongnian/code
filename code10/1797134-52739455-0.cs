    var result = xDoc.Descendants().Descendants(ns + "RentalSession")
                                .Where(x => x.Element(ns + "VehicleRefId").Value != null)
                                .Select(x => new
                                {
                                    _VehicleRefId = (string)x.Element("VehicleRefId"),
                                    _RentalSessionId = (string)x.Element("RentalSession),
                                    _startDate = (DateTime)x.Element("RentalPeriod),
                                    _endDate = (DateTime)x.Element("RentalPeriod"),
                                    _VehicleGroup = (string)x.Element("VehicleGroup"),
                                    _Notes = (string)x.Element("Notes")
                                }).ToList().Distinct();
