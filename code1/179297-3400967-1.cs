    public static string Version
    {
        get
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
            return String.Format("{0}.{1}", fvi.ProductMajorPart, fvi.ProductMinorPart);
        }
    }
