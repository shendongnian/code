    -- what the key table may look like
    CREATE TABLE Keys(Name VARCHAR(10) primary key, NextID INT)
    INSERT INTO Keys Values('sku',1)
    // some elements of the class
    public static SkuKeyGenerator 
    {
        private static syncObject = new object();
        private static int nextID = 0;
        private static int maxID = 0;
        private const int amountToReserve = 100;
    
        public static int NextKey()
        {
            lock( syncObject )
            {
                if( nextID == maxID )
                {
                    ReserveIds();
                }
                return nextID++;
            }
        }
        private static void ReserveIds()
        {
            // pseudocode - in reality I'd do this with a stored procedure inside a transaction,
            // We reserve some predefined number of keys from Keys where Name = 'sku'
            // need to run the select and update in the same transaction because this isn't the only
            // method that can use this table.
            using( Transaction trans = new Transaction() ) // pseudocode.
            {
                 int currentTableValue = db.Execute(trans, "SELECT NextID FROM Keys WHERE Name = 'sku'");
                 int newMaxID = currentTableValue + amountToReserve;
                 db.Execute(trans, "UPDATE Keys SET NextID = @1 WHERE Name = 'sku'", newMaxID);
                 trans.Commit();
                 nextID = currentTableValue;
                 maxID = newMaxID;
            }
        } 
