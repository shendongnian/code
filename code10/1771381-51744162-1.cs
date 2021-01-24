    Task.Factory.StartNew(
			async () =>
			{
				await Task.Factory.StartNew(
					() => { throw new Exception("inner"); },
					TaskCreationOptions.AttachedToParent);
		
				throw new Exception("outer");
			}).Wait();
		}
