    class DistinctItemComparer : IEqualityComparer<Item> {
    public bool Equals(Item x, Item y) {
        return x.Column == y.Column &&
            x.Line == y.Line &&
            x.Pdf == y.Pdf;
    }
    public int GetHashCode(Item obj) {
        return obj.Column.GetHashCode() ^
            obj.Line.GetHashCode() ^        
            obj.Pdf.GetHashCode();
    }
