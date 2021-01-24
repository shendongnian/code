    List<RECORDS> dataToInsert = objNewData.Except(objOldData, new InitializationKeysComparer()).ToList();
    
        public class InitializationKeysComparer : IEqualityComparer<RECORDS>
        {
            public bool Equals(RECORDS x, RECORDS y)
            {
                return (x.ENGINE.Trim().Equals(y.ENGINE.Trim()) && x.PRODH.Trim().Equals(y.PRODH.Trim())&& x.LANDX.Trim().Equals(y.LANDX.Trim()));
            }
    
            public int GetHashCode(RECORDS obj)
            {
                return 0;
            }
        }
