    if (!db.MyTable.Any(e => e.Col1 == myRow.Col1 && e.Col2 == myRow.Col2 && e.Col3 == myRow.Col3))
    {
         db.MyTable.Add(myRow);
    }
    else {
        // You can throw an exception here if you'd like but I usually prefer to return 'false' or some other indicator.
    }
