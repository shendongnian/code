    	public async Task<object> TryLotsOfTypesAndIgnoreErrors(string stateName)
		{
			var typeObj = Activator.CreateInstance(typeof(ActorStateManager));
			foreach (var typeParam in new[] {typeof(bool), typeof(string)})
			{
				try
				{
					var method = typeof(IActorStateManager).GetMethod(nameof(IActorStateManager.GetStateAsync));
					var generic = method.MakeGenericMethod(typeParam);
					var task = (Task) generic.Invoke(typeObj, new object[] { stateName, CancellationToken.None });
					await task;
					return task.GetType().GetProperty(nameof(Task<object>.Result))?.GetValue(task);
				}
				catch
				{
					// TODO: Catch only exception specific to type mismatch
				}
			}
			return null;
		}
