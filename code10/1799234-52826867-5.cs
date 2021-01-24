    var result = new GroupTestResult {
        A = r.ContainsKey("A") ? r["A"] : Enumerable.Empty<GroupTestResultItem>();,
        B = r.ContainsKey("B") ? r["B"] : Enumerable.Empty<GroupTestResultItem>();,
        C = r.ContainsKey("C") ? r["C"] : Enumerable.Empty<GroupTestResultItem>();,
    };
