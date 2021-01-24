    foreach (var actionModel in controllerModel.Actions)
    {
        if (!isApiController && !actionModel.Attributes.OfType<IApiBehaviorMetadata>().Any())
        {
            continue;
        }
        EnsureActionIsAttributeRouted(controllerHasSelectorModel, actionModel);
        AddInvalidModelStateFilter(actionModel);
        InferParameterBindingSources(actionModel);
        InferParameterModelPrefixes(actionModel);
        AddMultipartFormDataConsumesAttribute(actionModel);
    }
