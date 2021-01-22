    public static IEnumerable<TDataItem> GetDataItems<TData, TDataItem>(
        this IEnumerable<BarDto> dtos,
        Func<BarDto, TData> dataSelector,
        Func<BarDto, double> numberSelector,
        Func<TData, double, double, TDataItem> createDataItem)
        where TData : class
    {
        var eligibleDtos = dtos.Where(dto => dataSelector(dto) != null);
        var totalNumber = eligibleDtos.Sum(numberSelector);
        return
            from dto in eligibleDtos
            group dto by dataSelector(dto) into dtoGroup
            let groupNumber = dtoGroup.Sum(numberSelector)
            orderby groupNumber descending
            select createDataItem(dtoGroup.Key, groupNumber, groupNumber / totalNumber);
    }
