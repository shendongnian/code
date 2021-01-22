    public class MyRowComparer : IEqualityComparer<DataRow>
    {
     
        public bool Equals(DataRow x, DataRow y)
        {
            return (x.Field<int>("ID") == y.Field<int>("ID")) &&
                string.Compare(x.Field<string>("Name"), y.Field<string>("Name"), true) == 0 &&
              ... // extend this to include all your 4 keys...
        }
     
        public int GetHashCode(DataRow obj)
        {
            return obj.Field<int>("ID").GetHashCode() ^ obj.Field<string>("Name").GetHashCode() etc.
        }
    }
