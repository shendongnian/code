    private InternetExplorer GetIEWindow(string url)
    {
        SHDocVw.ShellWindowsClass sh = new ShellWindowsClass();
        InternetExplorer IE;
        for (int i = 1; i <= sh.Count; i++)
        {
            IE = (InternetExplorer)sh.Item(i);
            if (IE != null)
            {
                if (IE.LocationURL.Contains(url))
                {
                    return IE;
                }
            }
        }
        return null;
    }
