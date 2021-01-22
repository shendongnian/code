	using System;
	using System.Collections.Generic;
	using System.Reflection;
	namespace ConsoleApplication1
	{
		public delegate IEnumerable<BaseItem> GetListDelegate();
		public class BaseItem { }
		public class DerivedItem : BaseItem { }
		public static class Lists
		{
			public static GetListDelegate GetListDelegateForType(Type derivedType)
			{
				MethodInfo method = typeof(Lists).GetMethod("GetList", Type.EmptyTypes); // get the overload with no parameters
				method = method.MakeGenericMethod(new[] { derivedType });
				return (GetListDelegate)Delegate.CreateDelegate(typeof(GetListDelegate), method); // *** this throws an exception ***
			}
			// this is the one I want a delegate to, hence the Type.EmptyTypes above
			public static IEnumerable<T> GetList<T>() where T : class
			{// returns a collection of T items ... 
				return new T[0];
			}
			// not the one I want a delegate to; included for illustration, maybe my different GetMethod() is my problem?
			public static IEnumerable<T> GetList<T>(int param) where T : class
			{ // returns a collection of T items ... 
				return new T[0];
			}
		}
		public class GenericDelegate
		{
			public static void Test()
			{
				// I would call it like so, but first line gets exception, where indicated above
				GetListDelegate getList = Lists.GetListDelegateForType(typeof(BaseItem));
				IEnumerable<BaseItem> myList = getList();
			}
		}
	}
