    public static void Main() {
        var assembly = ...;
        Console.Write(CreateUsings(FilterToTopLevel(GetNamespaces(assembly))));
    }
    private static string CreateUsings(IEnumerable<string> namespaces) {
        return namespaces.Aggregate(String.Empty,
                                    (u, n) => u + "using " + n + ";" + Environment.NewLine);
    }
    private static IEnumerable<string> FilterToTopLevel(IEnumerable<string> namespaces) {
        return namespaces.Select(n => n.Split('.').First()).Distinct();
    }
    private static IEnumerable<string> GetNamespaces(Assembly assembly) {
        return (assembly.GetTypes().Select(t => t.Namespace)
                .Where(n => !String.IsNullOrEmpty(n))
                .Distinct());
    }
