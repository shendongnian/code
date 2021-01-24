	var doc = XDocument.Parse(xml);
	XNamespace ns = "http://autoinsight.trann.co.za/types";
	var result = doc
		.Descendants(ns + "VehicleValue")
		.Select(x => new
		{
			AdjustCostPrice = x.Element(ns + "AdjustCostPrice").Value,
			AdjEstCostPrice = x.Element(ns + "AdjEstCostPrice").Value,
			CostPrice = x.Element(ns + "CostPrice").Value,
			VehicleCode = x.Element(ns + "VehicleCode").Value,
            //etc
		});
