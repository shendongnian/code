    public static bool ContainsCI(this string target, string searchTerm)
    {
      int results = target.IndexOf(searchTerm, StringComparison.CurrentCultureIgnoreCase);
      return results == -1 ? false : true;
    }
