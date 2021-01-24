    public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
    {
         PrintManager = new PrintMgr(commandData);
         
         //...
         return Result.Succeeded;
    }
