        if (name != null)
        {
            page = 1;
        }
        else
        {
            name = (string)ViewData["CurrentFilterName"];
        }
        ViewData["CurrentFilterName"] = name;
        if (!String.IsNullOrEmpty(name))
            searchList = searchList.Where(m => m.Name.Contains(name)).ToList();
        if (className == null)
            className = (string)ViewData["CurrentFilterClassName"];
        ViewData["CurrentFilterClassName"] = className;
        if (!String.IsNullOrEmpty(className))
            searchList = searchList.Where(m => m.className.Contains(className)).ToList();
