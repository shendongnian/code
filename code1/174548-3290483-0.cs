    public static void Main()
    {
        typeof(ImageFormat).GetProperty("GetPng", BindingFlags.Public |
                                                  BindingFlags.Static);
    }
