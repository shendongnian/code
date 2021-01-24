    private static void Find()
    {
        var uniqueDataSets = dataSet1.Except(dataSet2, new DataComparer());
    }
    
    class DataComparer : IEqualityComparer<DataSet>
    {
        public bool Equals(DataSet x, DataSet y)
        {
            if (object.ReferenceEquals(x, y)) return true;
    
            return x?.ColA == y?.ColA && x?.ColB == y?.ColB;
        }
    
        public int GetHashCode(DataSet obj)
        {
            if (obj == null) return 0;
    
            return obj.ColA.GetHashCode() ^ obj.ColB.GetHashCode();
        }
    }
