csharp
public int? DatePart(string datePartArg, DateTime? date) => throw new Exception();
public void OnModelCreating(DbModelBuilder modelBuilder) {
    var methodInfo = typeof(DbContext).GetRuntimeMethod(nameof(DatePart), new[] { typeof(string), typeof(DateTime) });
    modelBuilder
        .HasDbFunction(methodInfo)
        .HasTranslation(args => new SqlFunctionExpression(nameof(DatePart), typeof(int?), new[]
                {
                        new SqlFragmentExpression(args.ToArray()[0].ToString()),
                        args.ToArray()[1]
                }));
}
Query:
csharp
repository.Where(x => dbContext.DatePart("weekday", x.CreatedAt) == DayOfWeek.Monday);
some more info: https://github.com/aspnet/EntityFrameworkCore/issues/10404
