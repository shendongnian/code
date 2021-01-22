    public IEnumerable<FooDataItem> GetDataItems<T>(IEnumerable<GridColumn> dtos,
        Func<BarDto, T> groupCriteria,
        Func<BarDto, double> dataSelector,
        Func<T, double, double, FooDataItem> resultFactory)
    {
        var validDtos = dtos.Where(d => groupCriteria(d) != null);
        double totalNumber = validDtos.Sum(dataSelector);
        return validDtos
            .GroupBy(groupCriteria)
            .OrderBy(g => g.Sum(dataSelector))
            .Select(gr => resultFactory(gr.Key,
                                        gr.Sum(dataSelector),
                                        gr.Sum(dataSelector) / totalNumber));
    }
