	public static bool IsPredicate(object obj) {
		var ty = obj.GetType();
		var invoke = ty.GetMethod("Invoke");
		return invoke != null && invoke.ReturnType == typeof(bool);
	}
