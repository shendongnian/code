    // the new DataTable
    var tbl = new DataTable();
    // load XML file
    var doc = XDocument.Load(@"c:\tmp\sess-test.xml");
  
    // get the leaf elements and their common ancestor
    var q = from elements in doc.Descendants()
            where elements.Descendants().Count() == 0
            group elements by  elements.Parent into cluster
            from item in cluster
            from Attributes in item.Attributes()
            select new 
                {  cluster.Key, // common ancestor
                   Attributes,  // elements attributes
                   AncestorAttributes = cluster.Key.AncestorsAndSelf().Attributes()  // attributes in Ancestors of the common element
    
                };
    
    // create a column for each Ancestor attribute
    foreach(var attr in q.GroupBy( b=> b.Key).SelectMany(b => b.First().AncestorAttributes)) 
    {
       if (tbl.Columns[attr.Name.LocalName] == null) {
              tbl.Columns.Add(attr.Name.LocalName);
        }
    }
    
    // create a column for each element attribute
    foreach(var grp in q)
    {
        if (tbl.Columns[grp.Attributes.Name.LocalName] == null) {
              tbl.Columns.Add(grp.Attributes.Name.LocalName);
        }
    }
    
    // build datatable
    var grps = q.GetEnumerator();
    bool next = grps.MoveNext();
    // for each group a new row  
    var curgrp = grps.Current.Key;
    var row = tbl.NewRow();
    // add attribute values to this row
    while(next)
    {
        if (curgrp != grps.Current.Key) {
            // new group, so new row
            tbl.Rows.Add(row);
            row = tbl.NewRow();
            curgrp = grps.Current.Key;
        }
        // attribute gets stored
        row[grps.Current.Attributes.Name.LocalName] = grps.Current.Attributes.Value ;
        // all attributes from the ancestors get stored
        foreach(var attr in grps.Current.AncestorAttributes)
        {
            row[attr.Name.LocalName] = attr.Value ;
        }
        next = grps.MoveNext();
    }
    tbl.Rows.Add(row);
