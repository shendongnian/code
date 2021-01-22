cs
    using System;
    public static class EnumExtensions<TEnum> where TEnum : unmanaged, Enum
    {
    	/// <summary>
    	/// Converts a <typeparam name="TEnum"></typeparam> into a <typeparam name="TResult"></typeparam>
    	/// through pointer cast.
    	/// Does not throw if the sizes don't match, clips to smallest data-type instead.
    	/// So if <typeparam name="TResult"></typeparam> is smaller than <typeparam name="TEnum"></typeparam>
    	/// bits that cannot be captured within <typeparam name="TResult"></typeparam>'s size will be clipped.
    	/// </summary>
    	public static TResult To<TResult>( TEnum value ) where TResult : unmanaged
    	{
    		unsafe
    		{
    			if( sizeof(TResult) > sizeof(TEnum) )
    			{
    				// We might be spilling in the stack by taking more bytes than value provides,
    				// alloc the largest data-type and 'cast' that instead.
    				TResult o = default;
    				*((TEnum*) & o) = value;
    				return o;
    			}
    			else
    			{
    				return * (TResult*) & value;
    			}
    		}
    	}
    	
    	/// <summary>
    	/// Converts a <typeparam name="TSource"></typeparam> into a <typeparam name="TEnum"></typeparam>
    	/// through pointer cast.
    	/// Does not throw if the sizes don't match, clips to smallest data-type instead.
    	/// So if <typeparam name="TEnum"></typeparam> is smaller than <typeparam name="TSource"></typeparam>
    	/// bits that cannot be captured within <typeparam name="TEnum"></typeparam>'s size will be clipped.
    	/// </summary>
    	public static TEnum From<TSource>( TSource value ) where TSource : unmanaged
    	{
    		unsafe
    		{
    			
    			if( sizeof(TEnum) > sizeof(TSource) )
    			{
    				// We might be spilling in the stack by taking more bytes than value provides,
    				// alloc the largest data-type and 'cast' that instead.
    				TEnum o = default;
    				*((TSource*) & o) = value;
    				return o;
    			}
    			else
    			{
    				return * (TEnum*) & value;
    			}
    		}
    	}
    }
Requires unsafe toggle in your project configuration.
Usage:
    int intValue = EnumExtensions<YourEnumType>.To<int>( yourEnumValue );
Edit: Replaced ``Buffer.MemoryCopy`` by simple pointer cast from dahall's suggestion.
  [1]: https://stackoverflow.com/users/1196360/dahall
