    public static void ShowAbout(Point? location = null
        bool stripSystemAssemblies = false,
        bool reflectionOnly = false)
    {
        // Default to point (1, 1) instead.
        Point realLocation = location ?? new Point(1, 1);
        ...
    }
