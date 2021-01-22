    bool tablesAreIdentical = true;
    
    // loop through first table
    foreach (DataRow row in firstTable.Rows)
    {
        foundIdenticalRow = false;
    
        // loop through tempTable to find an identical row
        foreach (DataRow tempRow in tempTable.Rows)
        {
            allFieldsAreIdentical = true;
            
            // compare fields, if any fields are different move on to next row in tempTable
            for (int i = 0; i < row.ItemArray.Length && allFieldsAreIdentical; i++)
            {
                if (!row[i].Equals(tempRow[i]))
                {
                    allFieldsAreIdentical = false;
                }
            }
            
            // if an identical row is found, remove this row from tempTable 
            //  (in case of duplicated row exist in firstTable, so tempTable needs
            //   to have the same number of duplicated rows to be considered equivalent)
            // and move on to next row in firstTable
            if (allFieldsAreIdentical)
            {
                tempTable.Rows.Remove(tempRow);
                foundIdenticalRow = true;
                break;
            }
        }
        // if no identical row is found for current row in firstTable, 
        // the two tables are different
        if (!foundIdenticalRow)
        {
            tablesAreIdentical = false;
            break;
        }
    }
    
    return tablesAreIdentical;
