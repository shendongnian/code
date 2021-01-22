	private void EventCallback(object sender, FileSystemEventArgs e)
	{
		var fileName = e.FullPath;
		if (!File.Exists(fileName))
		{
			// We've dealt with the file, this is just supressing further events.
			return;
		}
		// File exists, so move it to a working directory. 
		File.Move(fileName, [working directory]);
        // Kick-off whatever processing is required.
	}
