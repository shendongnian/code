		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool IsReEntry() {
			StackTrace stack = new StackTrace();
			StackFrame[] frames = stack.GetFrames();
			if (frames.Length < 2)
				return false;
			string currentMethod = frames[1].GetMethod().Name;
			for (int i = 2; i < frames.Length; i++) {
				if (frames[i].GetMethod().Name == currentMethod) {
					return true;
				}
			}
			return false;
		}
