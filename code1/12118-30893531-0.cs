	public static bool IsOnlyOneElement(this IList lst, Action callbackOnTrue = (Action)((null)), Action callbackOnFalse = (Action)((null)))
	{
		var isOnlyOne = lst.Count == 1;
		if (isOnlyOne && callbackOnTrue != null) callbackOnTrue();
		if (!isOnlyOne && callbackOnFalse != null) callbackOnFalse();
		return isOnlyOne;
	}
