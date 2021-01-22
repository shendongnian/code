    IEnumerable<String> GetLoadedAssemblies() {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
            yield return assembly.ToString();
        }
    }
