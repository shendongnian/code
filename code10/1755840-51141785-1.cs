    public class BaseObjectExtensions
	{
		public string Delete<T>(this T theObject) where T : BaseObject
		{
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
			{
				db.Delete(theObject);
			}
		}
	}
