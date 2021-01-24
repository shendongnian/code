	public class Connection
	{
		static Dictionary<string, Dictionary<Type, Delegate>> _dicActions = new Dictionary<string, Dictionary<Type, Delegate>>();
		public static void Request<T>(string key, Action<T> action) where T : BaseResponse
		{
			if (!_dicActions.ContainsKey(key))
			{
				_dicActions.Add(key, new Dictionary<Type, Delegate>());
			}
			_dicActions[key].Add(typeof(T), action);
		}
	
		public static void SetResponse<T>(string key, T pResponse) where T : BaseResponse
		{
			((Action<T>)_dicActions[key][typeof(T)])(pResponse);
		}
	}
