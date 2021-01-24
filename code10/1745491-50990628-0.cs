    options.Conventions.AddFolderRouteModelConvention("/", model =>
                       {
                           foreach (var selector in model.Selectors)
                           {
                               if (selector.AttributeRouteModel.Template.StartsWith("Admin"))
                               {
                                   selector.AttributeRouteModel = new AttributeRouteModel
                                   {
                                       Order = -1,
                                       Template =
                                           selector.AttributeRouteModel.Template,
                                   };
                               }
                               else
                               {
                                   selector.AttributeRouteModel = new AttributeRouteModel
                                   {
                                       Order = -1,
                                       Template = AttributeRouteModel.CombineTemplates(
                                           "{culture=en-US}",
                                           selector.AttributeRouteModel.Template),
                                   };
                               }
                           }
                       });
