    public static bool UserCanAccessThisPage(string userAccessGroups, string pageItemAccessGroups)
    {
        List<string> userAccessGroupsList = StringHelpers.SplitAndTrimCommaDelimitedString(userAccessGroups);
        List<string> pageItemAccessGroupList = StringHelpers.SplitAndTrimCommaDelimitedString(pageItemAccessGroups);
        return userAccessGroupsList.Where(
                              uag => pageItemAccessGroupList.Contains(uag)).Count > 0;
    }
    public static List<string> SplitAndTrimCommaDelimitedString(string line)
    {
        return line.Split(',').Select(s => s.Trim()).ToList<string>();
    }
