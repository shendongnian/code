    class SomeClass
    {
        private static IList<Column> localList;
        public static void Columns(Action<IList<Column>> action)
        {
            // Perform action using localList as parameter
            action(localList);
        }
    }
