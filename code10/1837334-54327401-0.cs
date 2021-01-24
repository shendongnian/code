       public class IndexerListModel : IEqualityComparer<IndexerListModel>
        {
            public string FilePath = string.Empty;
            public string uniqueID = string.Empty;
            public int GetHashCode(IndexerListModel co)
            {
                if (co == null)
                {
                    return 0;
                }
                return (co.FilePath + "^" + co.uniqueID).GetHashCode();
            }
            public bool Equals(IndexerListModel x1, IndexerListModel x2)
            {
                bool results = false;
                if ((x1.FilePath == x2.FilePath) && ( x1.uniqueID == x2.uniqueID))
                {
                    return true;
                }
                return false;
            }
        }
