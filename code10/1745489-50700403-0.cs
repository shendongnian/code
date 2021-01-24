    options.Conventions.AddFolderRouteModelConvention("/", model =>
    {
        var selectorCount = model.Selectors.Count;
        for (var i = 0; i < selectorCount; i++)
        {
            model.Selectors[i].AttributeRouteModel = new AttributeRouteModel
            {
                Order = -1,
                Template = AttributeRouteModel.CombineTemplates(
                    "{culture}",
                    model.Selectors[i].AttributeRouteModel.Template),
            };
        }
    });
