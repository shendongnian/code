    public class MapNameResolver : ValueResolver<string, string>{
    protected override string ResolveCore(string source)
    {
        return nameMap.ContainsKey(source) ? nameMap[value] : value;
    }
    private Dictionary<string, string> nameMap = new Dictionary<string, string>
    {
        {"xyz", "a"},
        {"abc", "123"}
    };
    }
