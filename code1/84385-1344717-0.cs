    class X : IOurTemplate<string, string>
	{
		#region IOurTemplate<string,string> Members
		IEnumerable<T> IOurTemplate<string, string>.List<T>()
		{
			throw new NotImplementedException();
		}
		T IOurTemplate<string, string>.Get<T, U>(U id)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
