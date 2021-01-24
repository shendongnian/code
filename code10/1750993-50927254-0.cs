    static readonly IDictionary<string,Func<object>> Makers = new Dictionary<string,Func<object>> {
        ["customerratesettingmodel"] = () => new CustomerRateSettingModel()
    };
    public static IHandleSearch GetClassInstanceForSearch(string className) {
        return Construct<IHandleSearch>(className);
    }
    public static IBaseFactory GetClassInstanceForSearch(string className) {
        return Construct<IBaseFactory>(className);
    }
    private static T Construct<T>(string className) where T : class {
        if (!Makers.TryGetValue(className.ToLower(), out var makeObject) {
            return null;
        }
        return makeObject() as T;
    }
