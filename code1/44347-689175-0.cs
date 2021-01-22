    public bool ShouldSerializeDt1() {
        return dt1 != null && dt1.Columns.Count > 0;
    }
    public bool ShouldSerializeDt2() {
        return dt2 != null && dt2.Columns.Count > 0;
    }
    public bool ShouldSerializeDt3() {
        return dt3 != null && dt3.Columns.Count > 0;
    }
