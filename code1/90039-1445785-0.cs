    public static string ToStringSafe(this DateTime? t) {
      return t.HasValue ? t.Value.ToString() : String.Empty;
    }
    ...
    var str = myVariable.ToStringSafe();
