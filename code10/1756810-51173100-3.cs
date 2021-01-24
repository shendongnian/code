    var r = xml
        .Descendants(ns + "DiskDriveInfo")
        .Select(x => new
        {
            ResultCode = x.Element(ns + "ResultCode").Value,
            ResultCodeDescription = x.Element(ns + "ResultCodeDescription").Value,
            AirbagDetails = x.Element(ns + "AirbagDetails").Value,
            ..
            ..
            WheelBase = x.Element(ns + "WheelBase").Value              
        });
