	public class WMIQuery
	{
		[SqlFunction(FillRowMethodName = "FillRow")]
		public static IEnumerable InitMethod()
		{
			ManagementScope scope = new ManagementScope();
			scope = new ManagementScope(@"\\localhost\root\CIMV2");
			scope.Connect();
			SelectQuery query = new SelectQuery("SELECT Name, Capacity, Freespace FROM Win32_Volume WHERE DriveType=3");
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
	 
			ManagementObjectCollection retObjectCollection = searcher.Get ( );
			return retObjectCollection;
		}
		public static void FillRow(Object obj, out SqlString Name, out SqlDecimal Capacity, out SqlDecimal Freespace)
		{
			ManagementObject m = (ManagementObject)obj;
		  
			Name = new SqlString((string)m["name"]);
	   
			Int64 int64cap;
			Int64.TryParse(m["Capacity"].ToString(), out int64cap);
			decimal decCap;
			decCap = int64cap / 1073741824; // to GB
			decCap = Math.Round(decCap, 2);
			Capacity = new SqlDecimal(decCap);
			Int64 int64Free;
			Int64.TryParse(m["Freespace"].ToString(), out int64Free);
			decimal decFree;
			decFree = int64Free / 1073741824; // to GB
			decFree = Math.Round(decFree, 2);
			Freespace = new SqlDecimal(decFree);
			
			
		}
	}
