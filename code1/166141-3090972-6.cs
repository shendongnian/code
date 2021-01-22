    static class Configuration
    {
        // only one instance of the object
    }
    class Data
    {
        private static int counter; // all Data objects access this one counter
        private int id;             // each Data object has a different id
    }
