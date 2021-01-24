	dynMethod.Invoke(this, new object[] {
		((Action<DB>)(db=> {
			MethodInfo dynMethod2 = db.GetType().GetMethod("Wiz", BindingFlags.NonPublic | BindingFlags.Instance);
			dynMethod2.Invoke(db, null);
	})) });
