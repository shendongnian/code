    public static class LibraryClass
    {
        public static void DoSomething(int positiveInteger)
        {
            if (positiveInteger < 0)
            {
                throw new ArgumentException("Expected a positive number", "positiveInteger");
            }
        }
    }
