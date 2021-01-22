    System.Collections.ObjectModel.Collection<PSObject>
    results = pipeline.Invoke();
     
    CustomCollection theCustumCollection
        = (CustomCollection )runspace.SessionStateProxy.GetVariable("results");
