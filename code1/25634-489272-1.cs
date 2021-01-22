    //Create XL
    Object xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
    //Get the workbooks collection.
    //   books = xl.Workbooks;
    Object books = xl.GetType().InvokeMember( "Workbooks", 
          BindingFlags.GetProperty, null, xl, null);
    //Add a new workbook.
    //   book = books.Add();
    Objet book = books.GetType().InvokeMember( "Add", 
          BindingFlags.InvokeMethod, null, books, null );
    //Get the worksheets collection.
    //   sheets = book.Worksheets;
    Object sheets = book.GetType().InvokeMember( "Worksheets",
          BindingFlags.GetProperty, null, book, null );
    Object[] parameters;
    //Get the first worksheet.
    //   sheet = sheets.Item[1]
    parameters = new Object[1];
    parameters[0] = 1;
    Object sheet = sheets.GetType().InvokeMember( "Item", 
          BindingFlags.GetProperty, null, sheets, parameters );
    //Get a range object that contains cell A1.
    //   range = sheet.Range["A1];
    parameters = new Object[2];
    parameters[0] = "A1";
    parameters[1] = Missing.Value;
    Object range = sheet.GetType().InvokeMember( "Range",
          BindingFlags.GetProperty, null, sheet, parameters );
    //Write "Hello, World!" in cell A1.
    //   range.Value = "Hello, World!";
    parameters = new Object[1];
    parameters[0] = "Hello, World!";
    objRange_Late.GetType().InvokeMember( "Value", BindingFlags.SetProperty, 
          null, range, parameters );
    //Return control of Excel to the user.
    //   xl.Visible = true;
    //   xl.UserControl = true;
    parameters = new Object[1];
    parameters[0] = true;
    xl.GetType().InvokeMember( "Visible", BindingFlags.SetProperty,
          null, xl, Parameters );
    xl.GetType().InvokeMember( "UserControl", BindingFlags.SetProperty,
          null, xl, Parameters );
    
