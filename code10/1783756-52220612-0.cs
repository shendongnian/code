    public static class CurrentUser
    {
        public static string Name; //Accessible with CurrentUser.Name
        public static string FamilyName; //Accessible with CurrentUser.FamilyName
        public static int Age; //Accessible with CurrentUser.Age
        public bool initialized = false //Accessible only through object which is created using CurrentUser
    }
