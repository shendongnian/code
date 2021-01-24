    XNamespace ns = "http://autoinsight.trn.co.za/types";
    var xml = XDocument.Parse(InXML);
    var r = from x in xml.Descendants(ns + "DiskDriveInfo")
            select new
            {
                ResultCode = x.Element(ns + "ResultCode").ValueOrNull(),
                ResultCodeDescription = x.Element(ns + "ResultCodeDescription").ValueOrNull(),
                AirbagDetails = x.Element(ns + "AirbagDetails").ValueOrNull(),
                ..
                ..
                WheelBase = x.Element(ns + "WheelBase").ValueOrNull()             
            };
