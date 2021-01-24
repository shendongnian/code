        [Test]
        public async Task Verify_ProjectDoesNotHaveNonASCIICharacters()
        {
            var project = workspace.CurrentSolution.Projects.Single(p => p.Name == "csproj_name");
            foreach (var document in project.Documents)
            {
                var semanticModel = await document.GetSemanticModelAsync();
                foreach (var item in semanticModel.SyntaxTree.GetRoot().DescendantNodes())
                {
                    switch (item)
                    {
                        // you may catch other Syntax types for methods, class names for example
                        case IdentifierNameSyntax identifierName: 
                            Assert.IsFalse(ContainsUnicodeCharacter(identifierName.Identifier.Text), $"Variable {identifierName.Identifier.Text} in {document.Name} contains non ASCII characters");
                        break;
                    }
                }
            }
        }
