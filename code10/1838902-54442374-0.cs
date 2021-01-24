    oSheet.Name = "Pivot Table";
    Excel.Range oRange2 = oSheet.Cells[10, 10];
    Excel.PivotCache pc = oBook.PivotCaches().Create(Excel.XlPivotTableSourceType.xlDatabase, oRange);
    Excel.PivotTable oPivotTable = pc.CreatePivotTable(oRange2, "Summary");
    Excel.Shape chart = oSheet.Shapes.AddChart(Excel.XlChartType.xl3DColumnClustered,
        100, 300, 500, 500);
    chart.Chart.SetSourceData(oPivotTable.TableRange1);
    oPivotTable.PivotFields("WW").Orientation = Excel.XlPivotFieldOrientation.xlRowField;
    oPivotTable.AddDataField(oPivotTable.PivotFields("MD"),
        "Sum of MD", Excel.XlConsolidationFunction.xlSum);
    oPivotTable.AddDataField(oPivotTable.PivotFields("MDC"), 
        "Sum of MDC", Excel.XlConsolidationFunction.xlSum);
