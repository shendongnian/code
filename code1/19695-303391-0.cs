	public static T Get<T>( this IDataRecord dr, int ordinal) 
	{
		T  nullValue = default(T);
		return dr.IsDBNull(ordinal) ? nullValue : (T) dr.GetValue(ordinal);
	}
	
    public void Code(params string[] args)
    {
		IDataRecord dr= null;
		int? a = Get<int?>(dr, 1);
		string b = Get<string>(dr, 2);
    }
