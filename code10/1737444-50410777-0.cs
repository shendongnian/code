    using Microsoft.Office.Interop.Excel;
    using System;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var connection = @"OLEDB;Provider=SQLOLEDB.1;Integrated Security=SSPI;Data Source=MYDATASOURCE;Initial Catalog=AdventureWorks2017";
                var command = "SELECT * FROM [Sales].[vSalesPersonSalesByFiscalYears]";
                var xl = new Application
                {
                    Visible = true
                };
                xl.Workbooks.Add();
                var pivotCache = xl.ActiveWorkbook.PivotCaches().Add(XlPivotTableSourceType.xlExternal, null);
                pivotCache.Connection = connection;
                pivotCache.MaintainConnection = true;
                pivotCache.CommandText = command;
                pivotCache.CommandType = XlCmdType.xlCmdSql;
                var sheet = (Worksheet)xl.ActiveSheet;
                var pivotTables = (PivotTables)sheet.PivotTables();
                var pivotTable = pivotTables.Add(pivotCache, xl.ActiveCell, "PivotTable1");
                pivotTable.SmallGrid = false;
                pivotTable.ShowTableStyleRowStripes = true;
                pivotTable.TableStyle2 = "PivotStyleLight1";
                PivotField pageField = (PivotField)pivotTable.PivotFields("SalesTerritory");
                pageField.Orientation = XlPivotFieldOrientation.xlPageField;
                PivotField rowField = (PivotField)pivotTable.PivotFields("FullName");
                rowField.Orientation = XlPivotFieldOrientation.xlRowField;
                pivotTable.AddDataField(pivotTable.PivotFields("2004"), "Sum of 2004", XlConsolidationFunction.xlSum);
            }
        }
    }
