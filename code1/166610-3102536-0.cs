		public static DataTable GetBannerImages(String bannerLocation, Int32 departmentId)
		{
			DataTable result = new DataTable();
			result.Locale = CultureInfo.CurrentCulture;
			Database db = DatabaseFactory.CreateDatabase("NamedConnectionStringFromConfig");
			using (DbCommand dbCommand = db.GetStoredProcCommand("proc_getBannerImages"))
			{
				db.AddInParameter(dbCommand, "BannerLocation", DbType.String, bannerLocation);
				db.AddInParameter(dbCommand, "DeptId", DbType.Int32, departmentId);
				using (IDataReader reader = db.ExecuteReader(dbCommand))
				{
					SopDataAdapter dta = new SopDataAdapter(); // descended from DbDataAdapter
					
					dta.FillFromReader(result, reader);
				} // using dataReader
			} // using dbCommand
			return result;
		} // method::GetBannerImages
