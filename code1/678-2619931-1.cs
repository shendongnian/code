    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    public static class Extensions
    {
    	public static TKey KeyByIndex<TKey,TValue>(this Dictionary<TKey, TValue> dict, int idx)
    	{
    		Type type = typeof(Dictionary<TKey, TValue>);
    		FieldInfo info = type.GetField("entries", BindingFlags.NonPublic | BindingFlags.Instance);
    		if (info != null)
    		{
    			// .NET
    			Object element = ((Array)info.GetValue(dict)).GetValue(idx);
    			return (TKey)element.GetType().GetField("key", BindingFlags.Public | BindingFlags.Instance).GetValue(element);
    		}
    		// Mono:
    		info = type.GetField("keySlots", BindingFlags.NonPublic | BindingFlags.Instance);
    		return (TKey)((Array)info.GetValue(dict)).GetValue(idx);
    	}
    };
