    options.Conventions.AddFolderRouteModelConvention("/", model =>
    {
        foreach (var selector in model.Selectors)
        {
            selector.AttributeRouteModel = new AttributeRouteModel
            {
                Order = -1,
                Template = AttributeRouteModel.CombineTemplates(
                    "{culture}",
                    selector.AttributeRouteModel.Template),
            };
        }
    });
