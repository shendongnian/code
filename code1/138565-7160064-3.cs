    public class SwigHelper
    {
    	public static T CastTo<T>(object from, bool cMemoryOwn)
    	{
    		System.Reflection.MethodInfo CPtrGetter = from.GetType().GetMethod("getCPtr", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
    		return CPtrGetter == null ? default(T) : (T) System.Activator.CreateInstance
    		(
    			typeof(T),
    			System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
    			null,
    			new object[] { ((HandleRef) CPtrGetter.Invoke(null, new object[] { from })).Handle, cMemoryOwn },
    			null
    		);
    	}
    }
