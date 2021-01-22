    if (!string.IsNullOrEmpty(str2)) {
      string s = Strings.Left(str2, 1);
      if (Strings.UCase(s) != s) {
        return false;
      }
    }
