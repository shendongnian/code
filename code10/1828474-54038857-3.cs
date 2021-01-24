	using Realms;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	namespace ReLife.Services.RealmRelated.RealmExtensions
	{
		public static class IQueryableExtensions
		{
			public static IQueryable<T> In<T>(this IQueryable<T> source, string propertyName, List<string> objList) where T : RealmObject
			{
				var query = string.Join(" OR ", objList.Select(i => $"{propertyName} == '{i}'"));
				var rez = source.Filter(query);
				return rez;
			}
			public static IQueryable<T> In<T>(this IQueryable<T> source, string propertyName, List<int> objList) where T : RealmObject
			{
				var query = string.Join(" OR ", objList.Select(i => $"{propertyName} == {i}"));
				var rez = source.Filter(query);
				return rez;
			}
		}
	}
