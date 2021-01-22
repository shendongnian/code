	using System;
	using System.Collections.Generic;
	using System.Web;
	public class MyListCache
	{
		private List<object> _MyList = null;
		public List<object> MyList {
			get {
				if (_MyList == null) {
					_MyList = (HttpContext.Current.Cache["MyList"] as List<object>);
					if (_MyList == null) {
						_MyList = new List<object>();
						HttpContext.Current.Cache.Insert("MyList", _MyList);
					}
				}
				return _MyList;
			}
			set {
				HttpContext.Current.Cache.Insert("MyList", _MyList);
			}
		}
		public void ClearList() {
			HttpContext.Current.Cache.Remove("MyList");
		}
	}
