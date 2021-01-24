    // Set the DrawMode property to the OwnerDrawVariable value. 
    // This means the MeasureItem and DrawItem events must be 
    // handled.
    ListBox1.DrawMode = DrawMode.OwnerDrawVariable;
    ListBox1.MeasureItem += new MeasureItemEventHandler(ListBox1_MeasureItem);
