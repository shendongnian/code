    var distinctRows = table.Rows.Cast<DataRow>().Distinct(new E());
    ...
    public class E : IEqualityComparer<DataRow>
    {
        bool IEqualityComparer<DataRow>.Equals(DataRow x, DataRow y)
        {
            return x["colA"] == y["colA"];
        }
        
        int IEqualityComparer<DataRow>.GetHashCode(DataRow obj)
        {
            return obj["colA"].GetHashCode();
        }
    }
