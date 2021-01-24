    XNamespace ns = "http://autoinsight.trn.co.za/types";
    var xml = XDocument.Parse(InXML);
    var r = from x in xml.Descendants(ns + "DiskDriveInfo")
            select new
            {
                ResultCode = x.Element(ns + "ResultCode").Value,
                ResultCodeDescription = x.Element(ns + "ResultCodeDescription").Value,
                AirbagDetails = x.Element(ns + "AirbagDetails").Value,
                ..
                ..
                WheelBase = x.Element(ns + "WheelBase").Value              
            };
