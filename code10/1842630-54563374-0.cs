    public static IQueryable<MyTable> WhereContains(this IQueryable<MyTable> source, string field, string value)
    {
      switch (field)
      {
        case nameof(MyTable.SomeField):
          return source.Where(a => a.SomeField.Contains(value));
        case nameof(MyTable.SomeOtherField):
          return source.Where(a => a.SomeOtherField.Contains(value));
        // ... etc
        default:
          throw new ArgumentOutOfRangeException($"Unexpected field {field}");
      }
    }
