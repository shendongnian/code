    if (System.Windows.Forms.Application.OpenForms.Count > 0)
    {
        return ApplicationType.WindowsForms;
    }
    
    if (System.Windows.Application.Current != null)
    {
        return ApplicationType.Wpf;
    }
    if (System.ServiceModel.OperationContext.Current != null)
    {
        return ApplicationType.Wcf;
    }
    try
    {
        int windowHeight = Console.WindowHeight; // an exception could occur
        return ApplicationType.Console;
    }
    catch (IOException)
    {
    }
    return ApplicationType.Unknown;
            
