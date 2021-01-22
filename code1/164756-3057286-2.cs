    public static IFileFilter FileFilter(string filterName)
    {
        switch (filterName)
        {
            case "Text Filter":
                return new TextFileFilter();
            case "RegEx Filter":
                return new RegExFileFilter();
            default:
                return new NoFileFilter();
        }
    }
