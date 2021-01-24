    private static IEnumerable<string> FindMissingElements(
           IEnumerable<Test> tests, IEnumerable<string> domain)
    {
       var sourceElements = tests.SelectMany(test => test.Lists).Distinct();
       var missing = domain.Except(sourceElements)
       return missing;
    }
