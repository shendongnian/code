    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace Microsoft.EntityFrameworkCore
    {
    	public static class IncludeExtensions
    	{
    		public static IQueryable<T> Include<T>(this IQueryable<T> source, IEnumerable<string> includePaths) where T : class
    			=> includePaths.Aggregate(source, (query, path) => query.Include(path));
    
    		public static IQueryable<T> Include<T>(this IQueryable<T> source, IEnumerable<Expression<Func<T, object>>> includePaths) where T : class
    			=> source.Include(includePaths.Select(e => GetIncludePath(e?.Body)));
    
    		static string GetIncludePath(Expression source, bool allowParameter = false)
    		{
    			if (allowParameter && source is ParameterExpression)
    				return null; // ok
    			if (source is MemberExpression member)
    				return CombinePaths(GetIncludePath(member.Expression, true), member.Member.Name);
    			if (source is MethodCallExpression call && call.Method.Name == "Select"
    				&& call.Arguments.Count == 2 && call.Arguments[1] is LambdaExpression selector)
    				return CombinePaths(GetIncludePath(call.Arguments[0]), GetIncludePath(selector.Body));
    			throw new Exception("Invalid Include path.");
    		}
    
    		static string CombinePaths(string path1, string path2)
    			=> path1 != null ? path1 + "." + path2 : path2;
    	}
    }
