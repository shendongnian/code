    var branches = new[] { "TUP", "LIT" };
    var result = 
        cDb.DistributionStopInformations
           .Join(cDb.DistributionRouteHeaders, info => info.Route_Code, h => h.Route_Code)
           .Where(info => info.Created_By == null)
           .Where(info => info.Shipment_Type == "D")
           .Where(info => branches.Contains(info.Branch_Id)) // WHERE Branch_Id IN (...)
           .ToList();
