    var builder = new ODataConventionModelBuilder();
    builder.EnumType<Appliance>();
    IEdmModel edmModel = builder.GetEdmModel();
    
    // Create a customize term and add it into the model.
    EdmTerm term = new EdmTerm("NS", "FooBar", EdmCoreModel.Instance.GetString(true));
    ((EdmModel)edmModel).AddElement(term);
    
    var member = enumType.Members.First(c => c.Name == "Stove");
    
    // Apply the annotation to the member with the new built term.
    EdmVocabularyAnnotation annotation = new EdmVocabularyAnnotation(member, term, new EdmStringConstant("Stove Top"));
    annotation.SetSerializationLocation(model, EdmVocabularyAnnotationSerializationLocation.Inline); // OutOfLine can't work for the 'EnumMember'.
    ((EdmModel)edmModel).SetVocabularyAnnotation(annotation);
