    Task ready = IsFileReady(path);
	ready.Wait(1000);
	if (!ready.IsCompleted)
	{
		throw new FileLoadException($"The file {path} is exclusively opened by another process!");
	}
	File.Delete(path);
