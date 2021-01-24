    public static void RemoveDataLabel(this ExcelBarChart chart, int serieNumber, int objectNumber)
    {
        var chartXml = chart.ChartXml;
        var nsa = chart.WorkSheet.Drawings.NameSpaceManager.LookupNamespace("a");
        var nsuri = chartXml.DocumentElement.NamespaceURI;
        var nsm = new XmlNamespaceManager(chartXml.NameTable);
        nsm.AddNamespace("a", nsa);
        nsm.AddNamespace("c", nsuri);
        var dLbls = chart.ChartXml.SelectSingleNode(@"c:chartSpace/c:chart/c:plotArea/c:barChart/c:ser[c:idx[@val='" + serieNumber + "']]/c:dLbls", nsm);
        var dLbl = chartXml.CreateNode(XmlNodeType.Element, "dLbl", nsuri);
        var idx = chartXml.CreateNode(XmlNodeType.Element, "idx", nsuri);
        var valueIdx = chartXml.CreateAttribute("val", nsuri);
        valueIdx.Value = objectNumber.ToString();
        idx.Attributes.Append(valueIdx);
        dLbl.AppendChild(idx);
        var delete = chartXml.CreateNode(XmlNodeType.Element, "delete", nsuri);
        var valueDelete = chartXml.CreateAttribute("val", nsuri);
        valueDelete.Value = "1";
        delete.Attributes.Append(valueDelete);
        dLbl.AppendChild(delete);
        dLbls.AppendChild(dLbl);
    }
