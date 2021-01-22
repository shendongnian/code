    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    public static class CSession
	{
		private static readonly string zE = "";
		private static readonly string CrLF = Environment.NewLine;
		private static bool bStopHere = true;
		/// <summary>
		/// Get a session variable
		/// </summary>
		/// <param name="pSessionKey"></param>
		/// <returns></returns>
		public static object Get(string pSessionKey)
		{
			object t = null;
			if (HttpContext.Current.Session[pSessionKey] != null) { t = (object)HttpContext.Current.Session[pSessionKey]; }
			return t;
		}//object Get(string pSessionKey)
		/// <summary>
		/// Set a session variable
		/// </summary>
		/// <param name="pSessionKey"></param>
		/// <param name="pObject"></param>
		public static void Set(string pSessKey, object pObject)
		{
			HttpContext.Current.Session.Remove(pSessKey);
			HttpContext.Current.Session.Add(pSessKey, pObject);
		}//void Set(string pSessionKey, object pObject)
		public static string GetString(string pSessKey)
		{
			string sTemp = zE;
			object t = Get(pSessKey);
			if (t != null) { sTemp = (string)t; } else { sTemp = zE; }
			return sTemp;
		}//string GetString(string pSessionKey)
		public static int GetInt(string pSessKey)
		{
			int s = 0;
			object t = Get(pSessKey);
			if (t != null) { s = (int)t; }
			return s;
		}//int GetInt(string pSessionKey)
		public static Int32 GetInt32(string pSessKey)
		{
			Int32 s = 0;
			object t = Get(pSessKey);
			if (t != null) { s = (Int32)t; }
			return s;
		}//Int32 GetInt32(string pSessionKey)
		public static bool GetBool(string pSessKey)
		{
			bool s = false;
			object t = Get(pSessKey);
			if (t != null) { s = (bool)t; }
			return s;
		}//bool GetBool(string pSessionKey)
	}//static class CSession
