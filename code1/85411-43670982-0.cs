            public string GetAlias(Type t)
            {
                string typeName = "";
                using (var provider = new CSharpCodeProvider())
                {
                    var typeRef = new CodeTypeReference(t);
                    typeName = provider.GetTypeOutput(typeRef);
                }
                return typeName;
            }
