    if (item.Title == "Movies")
    {               
        Type page = item.TargetType;
        var pageInstance = (HomePage)Activator.CreateInstance(page);
        // So now you already have your HomePage and you already checked 
        // in HomePage constructor for the value of MenuName, but it has
        // not been set yet, as it is set on the next line:
        pageInstance.MenuName = item.Title;
        Detail = new NavigationPage(pageInstance);
        IsPresented = false;
    }
