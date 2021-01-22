    static readonly Range InvalidUser = new Range(100, 200);
    static readonly Range MilkTooHot = new Range (300, 400);
    static readonly IEnumerable<Range> Errors =
        new List<Range> { InvalidUser, MilkTooHot };
    ...
    // Normal LINQ (where Range defines a Contains method)
    if (Errors.Any(range => range.Contains(statusCode))
    // or (extension method on int)
    if (statusCode.InAny(Errors))
    // or (extension methods on IEnumerable<Range>)
    if (Errors.Any(statusCode))
