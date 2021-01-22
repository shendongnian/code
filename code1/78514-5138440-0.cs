            XmlSchemas xsds = new XmlSchemas();
            xsds.Add(xsd);
            xsds.Compile(null, true);
            XmlSchemaImporter schemaImporter = new XmlSchemaImporter(xsds);
            // create the codedom
            CodeNamespace codeNamespace = new CodeNamespace(strNamespace);
            XmlCodeExporter codeExporter = new XmlCodeExporter(codeNamespace);
            List<XmlTypeMapping> maps = new List<XmlTypeMapping>();
            foreach (XmlSchemaType schemaType in xsd.SchemaTypes.Values)
            {
                maps.Add(schemaImporter.ImportSchemaType(schemaType.QualifiedName));
            }
            foreach (XmlSchemaElement schemaElement in xsd.Elements.Values)
            {
                maps.Add(schemaImporter.ImportTypeMapping(schemaElement.QualifiedName));
            }
            foreach (XmlTypeMapping map in maps)
            {
                codeExporter.ExportTypeMapping(map);
            }
            ReplaceArrayWithList(codeNamespace);
            // Check for invalid characters in identifiers
            CodeGenerator.ValidateIdentifiers(codeNamespace);
            // output the C# code
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            using (StreamWriter writer = new StreamWriter(strCsPath, false))
            {
                codeProvider.GenerateCodeFromNamespace(codeNamespace, writer, new CodeGeneratorOptions());
            }
        }
        private static void ReplaceArrayWithList(CodeNamespace codeNamespace)
        {
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
            {
                foreach (CodeTypeMember member in codeType.Members)
                {
                    if (member is CodeMemberField)
                    {
                        CodeMemberField field = (CodeMemberField)member;
                        if (field.Type.ArrayRank > 0)
                        {
                            CodeTypeReference type = new CodeTypeReference();
                            type.BaseType = "List<" + field.Type.BaseType + ">";
                            field.Type = type;
                        }
                    }
                    if (member is CodeMemberProperty)
                    {
                        CodeMemberProperty property = (CodeMemberProperty)member;
                        if (property.Type.ArrayRank > 0)
                        {
                            CodeTypeReference type = new CodeTypeReference();
                            type.BaseType = "List<" + property.Type.BaseType + ">";
                            property.Type = type;
                        }
                    }
                }
            }
        }
 
    }
}
