    bool IsSatisfyingNumber(String number) {
        // True if number satisfies some criteria
    }
    var matchingIds = myItems
        .Where(item => IsSatisfyingNumber(item[1].ToString()))
        .Select(item => item[0].ToString())
