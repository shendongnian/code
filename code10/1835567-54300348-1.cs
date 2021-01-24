    services.AddMvc()
        .AddRazorPagesOptions(options =>
        {
            options.Conventions.AddAreaFolderRouteModelConvention("Identity", "/Account/", model =>
             {
                 model.Selectors.ForEach(x =>
                 {
                     if (x.AttributeRouteModel.Template.StartsWith("Identity"))
                     {
                         x.AttributeRouteModel = new AttributeRouteModel()
                         {
                             Order = -1,
                             Template = AttributeRouteModel.CombineTemplates(("{culture=en-US}"),
                                 x.AttributeRouteModel.Template)
                         };
                     }
                 });
             });
        });
