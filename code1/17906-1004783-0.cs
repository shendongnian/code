    [CustomAction]
    public static ActionResult MyCustomAction(Session session)
    {
        string sourceDir = session["SourceDir"];
        string path = Path.Combine(sourceDir, "yourfilename.txt");
        ...
