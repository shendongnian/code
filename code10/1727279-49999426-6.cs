    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        Document doc = commandData.Application.ActiveUIDocument.Document;
        View activeView = commandData.View;
        string[,] values = null;
        if (activeView is ViewSchedule)
        {
            values = GetDimensions(activeView as ViewSchedule);
        }
        return Result.Succeeded;
    }
    public string[,] GetDimensions(ViewSchedule schedule)
    {
        //...
        return values;
    }
   
