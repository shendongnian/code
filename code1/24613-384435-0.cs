    IEnumerable<double> GetListFromFile(int idxItem)
    {
        // read data from file
        return dataReadFromFile;
    }
    IEnumerable<double> ConvertUnits(IEnumerable<double> items)
    {
        foreach(double item in items)
            yield return convertUnits(item);
    }
    IEnumerable<double> DoExpensiveProcessing(IEnumerable<double> items)
    {
        foreach(double item in items)
            yield return expensiveProcessing(item);
    }
    IEnumerable<double> GetNextList()
    {
        return DoExpensiveProcessing(ConvertUnits(GetListFromFile(curIdx++)));
    }
