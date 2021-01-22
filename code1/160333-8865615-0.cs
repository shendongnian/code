    public static bool IsReleaseBuild(this HtmlHelper helper)
    {
    #if DEBUG
        return false;
    #else
        return true;
    #endif
    }
