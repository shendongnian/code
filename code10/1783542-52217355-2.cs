    using System;
    using System.Linq;
    
    namespace Microsoft.EntityFrameworkCore
    {
    	public static class MyDbFunctions
    	{
    		[DbFunction("RIGHT", "")]
    		public static string Right(this string source, int length)
    		{
    			if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
    			if (source == null) return null;
    			if (length >= source.Length) return source;
    			return source.Substring(source.Length - length, length);
    		}
    
    		public static void Register(ModelBuilder modelBuider)
    		{
    			foreach (var dbFunc in typeof(MyDbFunctions).GetMethods().Where(m => Attribute.IsDefined(m, typeof(DbFunctionAttribute))))
    				modelBuider.HasDbFunction(dbFunc);
    		}
    	}
    }
