    public static void DoSomething(string testValue)
    {
        bool hasMatch = true;
        switch(testValue)
        {
            case "Test1":
                WL("Test1");
                break;
            case "Test2":
                WL("Test2");
                break;
            case "Test3":
                WL("Test3");
                break;
            default:
                WL("No match.");
                hasMatch = false;
                break;
        }
        if (hasMatch)
        {
            WL("Match found.");
        }
    }
