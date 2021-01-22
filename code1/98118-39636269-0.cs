    while (dataToProcess.Count > 0) {
    if  pointsToProcess.Contains(dataToProcess.Peek())
    {
    // processing data
    }
    else
    {
    // error message and
 
    dataToProcess.Dequeue();
    }
    }
