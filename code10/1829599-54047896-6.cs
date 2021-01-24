	public static bool DoesRecordExist(Dictionary<string,object> filters, DataTable dt)
	{
 		if (dt == null || dt.Rows.Count == 0) return false;
		return dt.AsEnumerable().Any(r => IsMatch(r, filters));
	}
