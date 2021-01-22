       public enum SelectedComparsionType
        {
            StartsWith,
            EndsWith,
            Contains
        }
    public static bool Like(this string searchString, string searchPattern, SelectedComparsionType searchType)
    {
        switch (searchType)
        {
            case SelectedComparsionType.StartsWith:
                return searchString.StartsWith(searchPattern);
            case SelectedComparsionType.EndsWith:
                return searchString.EndsWith(searchPattern);
            case SelectedComparsionType.Contains:
            default:
                return searchString.Contains(searchPattern);
        }
    }
