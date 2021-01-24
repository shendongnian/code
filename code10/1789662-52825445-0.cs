        private static void AddAnnotations(ref IEdmModel model, ODataConventionModelBuilder builder)
        {
            string enumName;
            string fullName;
            string memberName;
            string description;
            CustomAttributeData att;
            foreach (var enumTypeConfig in builder.EnumTypes)
            {
                foreach (var memberInfo in enumTypeConfig.ClrType.GetMembers())
                {
                    if (memberInfo.CustomAttributes.Any(a => a.AttributeType.Name == "DescriptionAttribute"))
                    {
                        enumName = enumTypeConfig.Name;
                        fullName = enumTypeConfig.FullName;
                        memberName = memberInfo.Name;
                        att = memberInfo.CustomAttributes.Where(a => a.AttributeType.Name == "DescriptionAttribute").Single();
                        description = att.ConstructorArguments[0].Value.ToString();
                        EdmTerm term = new EdmTerm("RESO.OData.Metadata", "StandardName", EdmCoreModel.Instance.GetString(true));  //TODO:  This will need to 1 of 2 choices depending on if Enum is standard or extended.
                        ((EdmModel)model).AddElement(term);
                        EdmEnumType enumType = (EdmEnumType)model.SchemaElements.First(e => e.FullName() == fullName);
                        var member = enumType.Members.First(c => c.Name == memberName);
                        EdmVocabularyAnnotation annotation = new EdmVocabularyAnnotation(member, term, new EdmStringConstant(description));
                        annotation.SetSerializationLocation(model, EdmVocabularyAnnotationSerializationLocation.Inline);
                        ((EdmModel)model).SetVocabularyAnnotation(annotation);
                    }
                }
