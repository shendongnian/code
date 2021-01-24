	public class DataManager
	{
		public DataType GetDataByIdNameAge (uint id, string name, int age)
		{...}   
	}
	
	public class Builder
	{
		private DataManager _dataManager;
		public Builder()
		{
			_dataManager = new DataManager();
		}
		// Creates multiple Office objects
		public void Create()
		{
			var office = new Office(_dataManager.GetDataByIdNameAge);  // <---
		}
	}
	public class Office
	{
        // LMFTFU                        
		private Func<uint, string, int, DataType> _getDataByIdNameAge { get; }
        //                              ^^^^^^^^ don't forget the return datatype
		public Office(Func<uint, string, int, DataType> getDataByIdNameAge )
		{
			_getDataByIdNameAge = getDataByIdNameAge ;
		}
	}
