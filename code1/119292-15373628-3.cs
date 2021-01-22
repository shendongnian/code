    private static int CompareNavigatorViews(object x, object y)
    {
        if (x == null)
            if (y == null)
                return 0;
            else
                return -1;
        else
            if (y == null)
                return 1;
            else
            {
                AssemblyInfo xAssemblyInfo = new AssemblyInfo(Assembly.GetAssembly(x.GetType()));
                AssemblyInfo yAssemblyInfo = new AssemblyInfo(Assembly.GetAssembly(y.GetType()));
    
                return String.Compare(xAssemblyInfo.Title, yAssemblyInfo.Title);
            }
    }
