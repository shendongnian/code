    public static bool DoesRecordExist(IPredicate<DataRow> condition, DataTable dt) {
        if (dt != null && dt.Rows.Count > 0) {
            bool exists = dt.AsEnumerable().Where(r => predicate.Condition(r)).Any();
            return exists;
        } else {
            return false;
        }
    }
