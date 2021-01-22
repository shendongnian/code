    public static bool UserCanAccessThisPage(string userAccessGroups, string pageItemAccessGroups) {
      List<string> userAccessGroupsList = StringHelpers.SplitAndTrimCommaDelimitedString(userAccessGroups);
      List<string> pageItemAccessGroupList = StringHelpers.SplitAndTrimCommaDelimitedString(pageItemAccessGroups);
      return userAccessGroupsList.Any(userAccessGroup => pageItemAccessGroupList.Any(pageItemAccessGroup => userAccessGroup == pageItemAccessGroup));
      // or:
      // return userAccessGroupsList.Any(userAccessGroup => pageItemAccessGroupList.Contains(userAccessGroup));
    }
    public static List<string> SplitAndTrimCommaDelimitedString(string line) {
      return line.Split(',').Select(s => s.Trim()).ToList();
    }
