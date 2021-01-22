    // Get normal filepath of this assembly's permanent directory
    var path = new Uri(
        System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        ).LocalPath;
