        public static class PatternMatcher
        {
            static MethodInfo strictMatchPatternMethod;
            static PatternMatcher()
            {
                var typeName = "System.IO.PatternMatcher";
                var methodName = "StrictMatchPattern";
                var assembly = typeof(Uri).Assembly;
                var type = assembly.GetType(typeName, true);
                strictMatchPatternMethod = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public) ?? throw new MissingMethodException($"{typeName}.{methodName} not found");
            }
            /// <summary>
            /// Tells whether a given name matches the expression given with a strict (i.e. UNIX like) semantics.
            /// </summary>
            /// <param name="expression">Supplies the input expression to check against</param>
            /// <param name="name">Supplies the input name to check for.</param>
            /// <returns></returns>
            public static bool StrictMatchPattern(string expression, string name)
            {
                // https://referencesource.microsoft.com/#system/services/io/system/io/PatternMatcher.cs
                // If this class is ever exposed for generic use,
                // we need to make sure that name doesn't contain wildcards. Currently 
                // the only component that calls this method is FileSystemWatcher and
                // it will never pass a name that contains a wildcard.
                if (name.Contains('*')) throw new FormatException("Wildcard not allowed");
                return (bool)strictMatchPatternMethod.Invoke(null, new object[] { expression, name });
            }
        }
