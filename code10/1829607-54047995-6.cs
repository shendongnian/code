    public static bool DoesRecordExist(IPredicate<DataRow> condition, DataTable dt) {
        if (dt != null && dt.Rows.Count > 0) {
            bool exists = dt.AsEnumerable().Any(r => predicate.Condition(r));
            return exists;
        } else {
            return false;
        }
    }
