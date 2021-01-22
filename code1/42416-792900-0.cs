            public static void NotEmpty<T>(IEnumerable<T> collection, IScope scope)
            {
                if (!collection.Any())
                {
                    scope.Error("Enumerable can't be empty.");
                }
                scope.ValidateInScope(collection);
            }
        }
 
