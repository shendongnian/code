        services.AddMvc().AddRazorPagesOptions(o => o.Conventions.AddAreaFolderRouteModelConvention("Identity", "/Account/", model =>
        {
            foreach (var selector in model.Selectors)
            {
                var attributeRouteModel = selector.AttributeRouteModel;
                attributeRouteModel.Order = -1;
                attributeRouteModel.Template = attributeRouteModel.Template.Remove(0, "Identity".Length);
            }
        })
    ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
