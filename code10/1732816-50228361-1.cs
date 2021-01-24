    string colList = "";
    string valList = "";
    foreach (var col in columns)
    {
        if (colList.length == 0)
        {
            colList += ", " + col.ColumnName;
        }
        else
        {
            colList += col.ColumnName;
        }
        // repeat for Value
    }
    // Finally, join it all together.
