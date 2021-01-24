    public interface IGrouping {
        boolProp[] boolProp { get; }
        stringProp[] stringProp { get; }
        longProp[] longProp { get; }
        Dictionary<string, bool?> BoolProperties { get; }
        Dictionary<string, long?> LongProperties { get; }
        Dictionary<string, string> StringProperties { get; }
    }
