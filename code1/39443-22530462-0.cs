		private static bool NeedsCleaning ()
		{
			if (DummyRef.IsAlive) {
				return false;
			}
			DummyRef = new WeakReference (new object ());
			return true;
		}
