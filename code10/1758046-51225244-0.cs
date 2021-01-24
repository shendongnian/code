    void Main()
    {
    	Excel.Application xl = new Excel.Application();
    	var wb = xl.Workbooks.Add();
    	var pc = wb.PivotCaches().Add(XlPivotTableSourceType.xlExternal);
    	
    	pc.Connection = @"OLEDB;Provider=SQLNCLI11.0;server=.\SQLExpress2012;Database=Northwind;Trusted_connection=yes";
    	pc.CommandType = XlCmdType.xlCmdSql;
    	pc.CommandText = @"Select c.CustomerID, c.CompanyName, 
      o.orderId, o.orderDate, 
      e.FirstName+(' '+e.LastName) As Employee, 
      p.ProductName,
      od.UnitPrice, od.Quantity
      FROM  Customers c 
      INNER Join Orders o
      ON o.CustomerID = c.CustomerID
      INNER Join Employees e 
      ON e.EmployeeID = o.EmployeeID
      INNER Join [Order Details] od
      ON od.OrderID = o.OrderID 
      INNER Join products p 
      ON p.ProductID = od.ProductID
      order By p.ProductName";
    	
      var ws = (Excel.Worksheet)wb.ActiveSheet;
    	pc.CreatePivotTable(ws.Range["A1"], "myPivot");
    	var pt = (Excel.PivotTable)ws.PivotTables("myPivot");
    
    	pt.AddFields(new string[] {"ProductName"}, new string[] {"Employee"});
    	var pvf = (Excel.PivotField)pt.PivotFields("Quantity");
    	pvf.Orientation = XlPivotFieldOrientation.xlDataField;
    	xl.Visible=true;
    }
