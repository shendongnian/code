    myList.Select(s => {
        var result = new DtoTest() {
            TotalSamples = myList.Count(c => c.UserId == s.UserId),
            EvaluatedSamples = myList.Count(c => c.UserId == s.UserId && c.Status == Status.OK)
        };
        result.PercentageRealized = (result.TotalSamples / result.EvaluatedSamples) * 100;
        return result;
    });
