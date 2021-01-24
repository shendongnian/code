       private static void addScatterChartToEntityMetricSheet(ExcelWorksheet sheet, ExcelTable table, string labelColumnName, string graphName)
        {
            int columnIndexART = table.Columns["ART"].Position;
            ExcelRangeBase rangeART = table.WorkSheet.Cells[
                table.Address.Start.Row + 1,
                table.Address.Start.Column + columnIndexART,
                table.Address.End.Row,
                table.Address.Start.Column + columnIndexART];
            int columnIndexCPM = table.Columns["CPM"].Position;
            ExcelRangeBase rangeCPM = table.WorkSheet.Cells[
                table.Address.Start.Row + 1,
                table.Address.Start.Column + columnIndexCPM,
                table.Address.End.Row,
                table.Address.Start.Column + columnIndexCPM];
            int columnIndexLabels = table.Columns[labelColumnName].Position;
            ExcelRangeBase rangeLabels = table.WorkSheet.Cells[
                table.Address.Start.Row + 1,
                table.Address.Start.Column + columnIndexLabels,
                table.Address.End.Row,
                table.Address.Start.Column + columnIndexLabels];
            //Scatter plot of activities
            ExcelChart chart = sheet.Drawings.AddChart(graphName, eChartType.XYScatter);
            ExcelScatterChart chart1 = (ExcelScatterChart)chart;
            chart.SetPosition(0, 0, 2, 0);
            chart.SetSize(800, 300);
            chart.Legend.Remove();
            chart.XAxis.Title.Text = "ART";
            chart.XAxis.Title.Font.Size = 8;
            chart.YAxis.Title.Text = "CPM";
            chart.YAxis.Title.Font.Size = 8;
            chart.VaryColors = true;
            //chart1.BubbleScale = 50;
            ExcelChartSerie series = chart.Series.Add(rangeCPM, rangeART);
            ExcelScatterChartSerie series1 = (ExcelScatterChartSerie)series;
            series.Header = "ARTvsCPM";
            series1.DataLabel.ShowValue = true;
            series1.DataLabel.ShowCategory = true;
            series1.DataLabel.ShowValue = false;
            series1.DataLabel.ShowCategory = false;
            series1.DataLabel.Position = eLabelPosition.Top;
            series1.MarkerSize = 10;
            series1.Marker = eMarkerStyle.Diamond;
            #region Update scatter to include nice Tier labels
            // This is what the Chart looks looks like
            //<ser xmlns="http://schemas.openxmlformats.org/drawingml/2006/chart">
            //    <c:idx val="0" />
            //    <c:order val="0" />
            //    <c:tx>
            //        <c:v>ARTvsCPM</c:v>
            //    </c:tx>
            //    <c:dLbls>
            //        <c:dLblPos val="ctr" />
            //        <c:showLegendKey val="0" />
            //        <c:showVal val="1" />
            //        <c:showCatName val="1" />
            //        <c:showSerName val="0" />
            //        <c:showPercent val="0" />
            //        <c:showBubbleSize val="0" />
            //        <c:separator>
            //        </c:separator>
            //        <c:showLeaderLines val="0" />
            //        <c:extLst>   
            //            <c:ext uri="{CE6537A1-D6FC-4f65-9D91-7224C49458BB}" xmlns:c15="http://schemas.microsoft.com/office/drawing/2012/chart">  <<< Magic GUID!!!!! Ai caramba
            //                <c15:showDataLabelsRange val="1"/>   <<<< This is the thing that turns on the data labels range
            //                <c15:showLeaderLines val="0"/>
            //            </c:ext>
            //        </c:extLst>
            //    </c:dLbls>
            //    <c:spPr>
            //        <a:ln w="28575">
            //            <a:noFill />
            //        </a:ln>
            //    </c:spPr>
            //    <c:xVal>
            //        <c:numRef>
            //            <c:f>'5.Tiers.Hourly'!$F$19:$F$40</c:f>
            //        </c:numRef>
            //    </c:xVal>
            //    <c:yVal>
            //        <c:numRef>
            //            <c:f>'5.Tiers.Hourly'!$I$19:$I$40</c:f>
            //        </c:numRef>
            //    </c:yVal>
            //    <c:smooth val="0" />
            //    <c:extLst>
            //        <c:ext uri="{02D57815-91ED-43cb-92C2-25804820EDAC}" xmlns:c15="http://schemas.microsoft.com/office/drawing/2012/chart">   <<< Magic GUID!!!!! Ai caramba
            //            <c15:datalabelsRange>
            //                <c15:f>'5.Tiers.Hourly'!$C$19:$C$40</c15:f>  <<<<< This is what specifies the range
            //            </c15:datalabelsRange>
            //        </c:ext>
            //    </c:extLst>
            //</ser>
            XmlDocument chartXMLdoc = chart.ChartXml;
            XmlNamespaceManager manager = new XmlNamespaceManager(chartXMLdoc.NameTable);
            manager.AddNamespace("c", "http://schemas.openxmlformats.org/drawingml/2006/chart");
            manager.AddNamespace("c15", "http://schemas.microsoft.com/office/drawing/2012/chart");
            XmlNode seriesXmlNode = chartXMLdoc.GetElementsByTagName("ser")[0];
            // Turn on labels
            // /ser/c:dLbls/c:extLst/c:ext/c15:showDataLabelsRange
            XmlNode labelXmlNode = seriesXmlNode.SelectSingleNode("c:dLbls", manager);
            XmlNode extLstXmlNode = chartXMLdoc.CreateElement("c:extLst", "http://schemas.openxmlformats.org/drawingml/2006/chart");
            labelXmlNode.AppendChild(extLstXmlNode);
            XmlNode extXmlNode = chartXMLdoc.CreateElement("c:ext", "http://schemas.openxmlformats.org/drawingml/2006/chart");
            XmlAttribute attribXmlAttribute = chartXMLdoc.CreateAttribute("uri");
            attribXmlAttribute.Value = "{CE6537A1-D6FC-4f65-9D91-7224C49458BB}";
            extXmlNode.Attributes.Append(attribXmlAttribute);
            extLstXmlNode.AppendChild(extXmlNode);
            XmlNode showDataLabelsRangeXmlNode = chartXMLdoc.CreateElement("showDataLabelsRange", "http://schemas.microsoft.com/office/drawing/2012/chart");
            attribXmlAttribute = chartXMLdoc.CreateAttribute("val");
            attribXmlAttribute.Value = "1";
            showDataLabelsRangeXmlNode.Attributes.Append(attribXmlAttribute);
            extXmlNode.AppendChild(showDataLabelsRangeXmlNode);
            // Specify label range
            // /ser/c:extLst/c:ext/c15:datalabelsRange/c15:f
            extLstXmlNode = chartXMLdoc.CreateElement("c:extLst", "http://schemas.openxmlformats.org/drawingml/2006/chart");
            seriesXmlNode.AppendChild(extLstXmlNode);
            extXmlNode = chartXMLdoc.CreateElement("c:ext", "http://schemas.openxmlformats.org/drawingml/2006/chart");
            attribXmlAttribute = chartXMLdoc.CreateAttribute("uri");
            attribXmlAttribute.Value = "{02D57815-91ED-43cb-92C2-25804820EDAC}";
            extXmlNode.Attributes.Append(attribXmlAttribute);
            extLstXmlNode.AppendChild(extXmlNode);
            XmlNode datalabelsRangeXmlNode = chartXMLdoc.CreateElement("datalabelsRange", "http://schemas.microsoft.com/office/drawing/2012/chart");
            extXmlNode.AppendChild(datalabelsRangeXmlNode);
            XmlNode fXmlNode = chartXMLdoc.CreateElement("f", "http://schemas.microsoft.com/office/drawing/2012/chart");
            fXmlNode.InnerText = rangeLabels.FullAddress;
            datalabelsRangeXmlNode.AppendChild(fXmlNode);
            #endregion
        }
