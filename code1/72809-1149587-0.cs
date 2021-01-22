    public static IEnumerable<double> GetEnum(int param) {
        if (!IsValidParameter(param)) {
            throw new Exception();
        }
        return GetEnumCore(param);
    }
    private static IEnumerable<double> GetEnumCore(int param) {
        while(true) {
            yield return 5.0;
        }
    }
