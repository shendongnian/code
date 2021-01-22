    void AddToDataTableWithJoins(DataTable table, object[] objects,
      string specification)
    {
      // 1. Split specification into parts on semicolon separator
      string[] specificationParts = ...
      // 2. Split parts into name lists (split on dot)
      string[][] specificationPartsNameLists = ...
      // 3. Set up columns (use first object's field types as example)
      for (int c=0; c<specificationParts.length; c++) {
        string mungedSpecPart = // might replace "." with something, does "_" work?
        table.Columns.Add(mungedSpecPart,
          getTypeForPath(specificationPartsNameLists[c],
          objects[0]));
      }
      // 4. Set up row values container
      object[] rowItems = new object[specificationParts.length];
      for (int d=0; d < objects.length; d++) {
        object obj = objects[d];
        for (int c=0; c < specificationParts.length; c++) {
          // 5. Add row values
          rowItems[c] = getValueForPath(specificationPartsNameLists[c], obj);
        }
        // 6. Invoke row add
        SomeInvokerFramework.invoke(table.Rows, "Add", rowItems);
      }
      // 7. Return
    }
    
    object getTypeForPath(string[] path, object inObject) {
      // do reflection-ey stuff to retrieve named data path and return type
    }
    object getValueForPath(string[] path, object object) {
      // do reflection-ey stuff to retrieve named data path and return value
    }
