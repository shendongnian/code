    public static IMyDatabase GetDb(string scope = "dev") {
    dynamic db;
    if (Globals.db == null) {
        switch (scope.ToLower()) {
        case "tns":
            return new TnsDb();
        case "sng":
            return new SngDb();
        default:
            return new TnsDb();
        }
    }
