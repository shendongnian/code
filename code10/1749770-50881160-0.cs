     if (modelTypeInfo.IsAbstract || modelTypeInfo.GetConstructor(Type.EmptyTypes) == null)
     {
        var metadata = bindingContext.ModelMetadata;
        switch (metadata.MetadataKind)
        {
            case ModelMetadataKind.Parameter:
                throw new InvalidOperationException(
                    Resources.FormatComplexTypeModelBinder_NoParameterlessConstructor_ForParameter(
                        modelTypeInfo.FullName,
                        metadata.ParameterName));
            case ModelMetadataKind.Property:
                throw new InvalidOperationException(
                    Resources.FormatComplexTypeModelBinder_NoParameterlessConstructor_ForProperty(
                        modelTypeInfo.FullName,
                        metadata.PropertyName,
                        bindingContext.ModelMetadata.ContainerType.FullName));
            case ModelMetadataKind.Type:
                throw new InvalidOperationException(
                    Resources.FormatComplexTypeModelBinder_NoParameterlessConstructor_ForType(
                        modelTypeInfo.FullName));
        }
    }
