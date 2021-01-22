    class IDPool
    { 
        private Dictionary<int, ID> ids = new Dictionary<int, ID>();
        public ID Get(int id)
        {
        //get ID from the shared pool or create new instance in the pool.
        //always returns same ID instance for given integer
        }
    }
