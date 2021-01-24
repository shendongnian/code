    services
        .AddMvc()
        .AddRazorPagesOptions(options =>
        {
            options.Conventions.AddFolderRouteModelConvention("/", model =>
            {
                var selectorCount = model.Selectors.Count;
    
                // Go down in reverse order to simply removing from a list being iterated.
                for (var i = selectorCount - 1; i >= 0; i--)
                {
                    var selectorTemplate = model.Selectors[i].AttributeRouteModel.Template;
    
                    if (selectorTemplate.EndsWith("Index")) // Perhaps be more specific here.
                        model.Selectors.RemoveAt(i);
                }
            });
        });
