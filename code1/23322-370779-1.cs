	public static class ModelStateDictionaryExtensions
	{
		public static void AddModelWarning(this ModelStateDictionary msd, string key, Exception exception)
		{
			GetModelStateForKey(key, msd).Warnings.Add(exception);
		}
		public static void AddModelWarning(this ModelStateDictionary msd, string key, string errorMessage)
		{
			GetModelStateForKey(key, msd).Warnings.Add(errorMessage);
		}
		private static AetherModelState GetModelStateForKey(string key, ModelStateDictionary msd)
		{
			ModelState state;
			if (string.IsNullOrEmpty(key))
				throw new ArgumentException("key");
			if (!msd.TryGetValue(key, out state))
			{
				msd[key] = state = new AetherModelState();
			}
			if (!(state is AetherModelState))
			{
				msd.Remove(key);
				msd[key] = state = new AetherModelState(state);
			}
			return state as AetherModelState;
		}
		public static bool HasWarnings(this ModelStateDictionary msd)
		{
			return msd.Values.Any<ModelState>(delegate(ModelState modelState)
			{
				var aState = modelState as AetherModelState;
				if (aState == null) return true;
				return (aState.Warnings.Count == 0);
			});
		}
	}
