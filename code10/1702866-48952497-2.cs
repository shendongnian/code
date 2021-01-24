    public static IEnumerable<Result> FilterResults(List<Result> results) {
        var filteredResults = results.Where(c => {
            bool filterTrue = SomeFilter(c);
            return filterTrue;
        });
        NextLine();
        return filteredResults;
    }
    ...
    foreach (var res in FilterResults(results)) {
        ... // The condition inside FilterResults method would get hit each time the loop iterates
    }
