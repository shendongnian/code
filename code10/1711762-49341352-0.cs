    |               Method |     Mean |    Error |   StdDev | Allocated |
    |--------------------- |---------:|---------:|---------:|----------:|
    |     Benchmark_Single | 306.8 ns | 2.867 ns | 2.682 ns |       0 B |
    | Benchmark_Reflection | 581.8 ns | 3.062 ns | 2.864 ns |       0 B |
-
    namespace ConsoleApp3
    {
    	using System;
    	using System.Linq.Expressions;
    	using System.Reflection;
    
    	public static class TempSingle<T>
    		where T : struct
    	{
    		public static T DoCustom()
    		{
    			if (typeof(T) == typeof(int))
    			{
    				return (T)((object)int.MinValue);
    			}
    			else if (typeof(T) == typeof(ushort))
    			{
    				return (T)((object)ushort.MinValue);
    			}
    
    			return default;
    		}
    	}
    
    	public static class TempReflection<T>
    		where T : struct
    	{
    		public readonly static Func<T> Factory = GetFactory();
    
    		private static int GetDefaultInt32()
    		{
    			return int.MinValue;
    		}
    
    		private static ushort GetDefaultUInt16()
    		{
    			return ushort.MinValue;
    		}
    
    		private static Func<T> GetFactory()
    		{
    			Type type = typeof(T);
    
    			MethodInfo method = typeof(TempReflection<T>)
    				.GetMethod($"GetDefault{type.Name}", BindingFlags.Static | BindingFlags.NonPublic);
    
    			return Expression
    				.Lambda<Func<T>>(Expression.Call(method))
    				.Compile();
    		}
    
    		public static T DoCustom()
    		{
    			return default;
    		}
    	}
    }
