    Dictionary<String, Type> modelsById = new Dictionary<String, Type>();
    String viewModelInterface = typeof(IPageItemViewModel).FullName;
        
    // get the assembly
    Assembly assembly = Assembly.GetAssembly(typeof(IPageItemViewModel));
    // iterate through all types
    foreach (Type viewModel in assembly.GetTypes())
    {
        // get classes which implement IPageItemViewModel
        if (viewModel.GetInterface(viewModelInterface) != null)
        {
            // get the attribute we're interested in
            foreach (Attribute att in Attribute.GetCustomAttributes(viewModel))
            {
                if (att is SupportsPageItemAttribute)
                {
                    // get the page item id
                    String id = (att as SupportsPageItemAttribute).ID;
                        
                    // add to dictionary
                    modelsById.Add(id, viewModel);
                }
            }
        }
    }
