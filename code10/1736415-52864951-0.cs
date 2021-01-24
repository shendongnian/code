    string xlFile = @"c:\temp\epp\epptest.xlsx";
    string sheetName = "TestData";
    string ChartName = "lineChartTest";
    DisplaySheetNode(xlFile, sheetName, ChartName);
       
      
        public void DisplaySheetNode(string xlsFile, string sheetname,string sChartName)
        {
            FileInfo existingFile = new FileInfo(xlsFile);
            using (var package = new ExcelPackage(existingFile))
            {
                var ws = package.Workbook.Worksheets[sheetname];
                var drawings = ws.Drawings;
                var chart = (ExcelLineChart)drawings[sChartName];
                var nsm = drawings.NameSpaceManager;
                var nschart = nsm.LookupNamespace("c");
                var nsa = nsm.LookupNamespace("a");
                var doc = chart.ChartXml;
                // var node = 
    chart.ChartXml.SelectSingleNode(@"c:chartSpace/c:chart/c:plotArea/c:valAx/c:txPr/a:bodyPr", nsm);
    
                    //var node = chart.ChartXml.SelectSingleNode(@"c:chartSpace/c:chart/c:plotArea/c:valAx", nsm);
                    var node = chart.ChartXml.SelectSingleNode(@"c:chartSpace/c:chart/c:plotArea/c:catAx", nsm);
                System.Diagnostics.Debug.WriteLine(PrintXMLNode(node));
            }
        }
    
