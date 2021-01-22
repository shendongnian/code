    Excel.Range rng = myWorksheet.get_Range("A1:D4", Type.Missing);
    
    //Get a 2D Array of values from the range in one shot:
    object[,] myArray = (object[,])rng.get_Value(Type.Missing);
    // Process 'myArray' however you want here.
    // Note that the Array returned from Excel is base 1, not base 0.
    // To be safe, use GetLowerBound() and GetUpperBound:
    for (int row = myArray.GetLowerBound(0); row < myArray.GetUpperBound(0); row++)
    {
        for (int column = myArray.GetLowerBound(1); column < myArray.GetUpperBound(1); column++)
        {
            if (myArray[row, column] is double)
            {
                myArray[row, column] = (double)myArray[row, column] * 2;
            }
        }
    }
    
    // Pass back the results in one shot:
    rng.set_Value(Type.Missing, myArray);
