            var firstAttribute = classNode.AttributeLists.First().Attributes.First();
            var attributeName = firstAttribute.Name.NormalizeWhitespace().ToFullString();
            Console.WriteLine(attributeName);
            // prints --> "MyAttribute"
            var firstArgument = firstAttribute.ArgumentList.Arguments.First();
            var argumentFullString = firstArgument.NormalizeWhitespace().ToFullString();
            Console.WriteLine(argumentFullString);
            // prints --> Test = "Hello"
            var argumentName = firstArgument.NameEquals.Name.Identifier.ValueText;
            Console.WriteLine(argumentName);
            // prints --> Test
            var argumentExpression = firstArgument.Expression.NormalizeWhitespace().ToFullString();
            Console.WriteLine(argumentExpression);
            // prints --> "Hello"
