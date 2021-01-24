    // Names adjusted for convention
    class Whatever
    {
        private ReadSql readSql;
        private QueryHandler queryHandler;
        public Whatever()
        {
            readSql = new ReadSql();
            queryHandler = new QueryHandler(readSql);
        }
    }
