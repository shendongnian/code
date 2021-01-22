    using System;
    public static class EnumExtensions<TEnum> where TEnum : unmanaged, Enum
    {
    	/// <summary>
    	/// Will fail if <see cref="TResult"/>'s type is smaller than <see cref="TEnum"/>'s underlying type
    	/// </summary>
    	public static TResult To<TResult>( TEnum value ) where TResult : unmanaged
    	{
    		unsafe
    		{
    			TResult outVal = default;
    			Buffer.MemoryCopy( &value, &outVal, sizeof(TResult), sizeof(TEnum) );
    			return outVal;
    		}
    	}
    	
    	public static TEnum From<TSource>( TSource value ) where TSource : unmanaged
    	{
    		unsafe
    		{
    			TEnum outVal = default;
    			long size = sizeof(TEnum) < sizeof(TSource) ? sizeof(TEnum) : sizeof(TSource);
    			Buffer.MemoryCopy( &value, &outVal, sizeof(TEnum), size );
    			return outVal;
    		}
    	}
    }
