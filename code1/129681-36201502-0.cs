    MethodInfo mI = null;
    Type baseType = someObject.GetType();
    while (mI == null)
    {
    	mI = baseType.GetMethod("SomePrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
    	baseType = baseType.BaseType;
    	if (baseType == null) break;
    }
    mI.Invoke(someObject, new object[] {});
