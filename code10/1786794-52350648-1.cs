    public class Comparer : IEqualityComparer<Key>
    {
        public bool Equals(Key x, Key y)
        {
            if (x.UnitPoints != y.UnitPoints) return false;
            if (!ListsAreEqual(x.Texts, y.Texts)) return false;
            return true;
        }
        private bool ListsAreEqual(List<TranslationData> x, List<TranslationData> y)
        {
            if (x.Count != y.Count) return false;
            for (int i = 0; i < x.Count; i++)
                if (x[i].Text != y[i].Text)
                    return false;
            return true;
        }
        public int GetHashCode(Key key)
        {
            int hash = 13;
            hash = (hash * 7) + key.UnitPoints.GetHashCode();
            foreach (var data in key.Texts)
                hash = (hash * 7) + data.Text.GetHashCode();
            return hash;
        }
    }
