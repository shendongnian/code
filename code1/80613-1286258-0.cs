    public class CSV
    {
        final private String filename;
        private String[][] data;
        private boolean loaded;
        public CSV(String filename) { ... }
        public boolean isLoaded() { ... }
        public void load() { ... }
        public void saveChanges() { ... }
        public void insertRowAt(int rowIndex, String[] row) { ... }
        public void sortRowsByColumn(int columnIndex) { ... }
        ...
    }
    public class CSVReader
    {
        /*
         * This kind of thing is reasonably implemented as a subclassable singleton
         * because it doesn't hold state but you might want to subclass it, perhaps with
         * a processor class for another tabular file format.
         */
        protected CSVReader();
        protected static class SingletonHolder
        {
            final public static CSVReader instance = new CSVReader();
        }
        public static CSVReader getInstance()
        {
            return SingletonHolder.instance;
        }
        public String getCell(String filename, int row, int column) { ... }
        public String searchRelative(String filename,
            String searchValue,
            int searchColumn,
            int returnColumn)
        { ... }
        ...
    }
