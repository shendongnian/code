    bool isWritable = true;
    try
    {
        using (Domain d = Domain.GetCurrentDomain())
            var dc = d.FindDomainController(theDomainController.Name, LocatorOptions.WriteableRequired);
    }
    catch(ActiveDirectoryObjectNotFoundException)
    {
        isWritable = false;
    }
