    var items = new[] { line1, line2, suburb, state, ... };
    var values = items.Where(s => !string.IsNullOrEmpty(s));
    var builder = new StringBuilder(128);
    values.Aggregate(builder, (b, s) => b.Append(s).Append(" "));
    var addr = builder.ToString(0, builder.Length - 1);
