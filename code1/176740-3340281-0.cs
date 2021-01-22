    DataColumn carmake = new DataColumn("make", typeof(string)); 
    DataColumn carcolor = new DataColumn("color", typeof(string)); 
    DataColumn carpetname = new DataColumn("petname", typeof(string));
    
    // Your missing this part:
    inventorytable.Columns.Add(carmake);
    inventorytable.Columns.Add(carcolor);
    inventorytable.Columns.Add(carpetname);
    
