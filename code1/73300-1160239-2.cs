    foreach(string x in newsplit.ToList()) {
        AssignmentAction(x);
    }
    ...
    public static void AssignmentAction(string x) {
        x = "WW";
    }
