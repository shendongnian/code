    /// <summary>
    /// Returns nullable Guid (Guid?) value if not null or Guid.Empty, otherwise returns DBNull.Value
    /// </summary>
    public static object GetValueOrDBNull(this Guid? aGuid)
    {
      return (!aGuid.IsNullOrEmpty()) ? (object)aGuid : DBNull.Value;
    }
    /// <summary>
    /// Determines if a nullable Guid (Guid?) is null or Guid.Empty
    /// </summary>
    public static bool IsNullOrEmpty(this Guid? aGuid)
    {
      return (!aGuid.HasValue || aGuid.Value == Guid.Empty);
    }
