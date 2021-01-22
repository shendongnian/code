    public static SubType DowncastSwigWrapper<BaseType, SubType>(BaseType from)
    {
    	System.Reflection.MethodInfo CPtrGetter = typeof(BaseType).GetMethod("getCPtr", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
    	return CPtrGetter == null ? default(SubType) : (SubType) Activator.CreateInstance
    	(
    		typeof(SubType),
    		System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
    		null,
    		new object[] { ((HandleRef) CPtrGetter.Invoke(null, new object[] { from })).Handle, false },
    		null
    	);
    }
