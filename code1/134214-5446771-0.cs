	var switchThreadForFsEvent = (Func<FileSystemEventHandler, FileSystemEventHandler>)(
			(FileSystemEventHandler handler) =>
					(object obj, FileSystemEventArgs e) =>
						Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
							handler(obj, e))));
	var switchThreadForFsRenameEvent = (Func<RenamedEventHandler, RenamedEventHandler>)(
				(RenamedEventHandler handler) =>
					(object obj, RenamedEventArgs e) =>
						Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
							handler(obj, e))));
	_fileSystemWatcher = new FileSystemWatcher(documentCollectionPath);
	_fileSystemWatcher.Created += switchThreadForFsEvent(OnFileCreated);
	_fileSystemWatcher.Deleted += switchThreadForFsEvent(OnFileDeleted);
	_fileSystemWatcher.Renamed += switchThreadForFsRenameEvent(OnFileRenamed);
	_fileSystemWatcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName;
	_fileSystemWatcher.IncludeSubdirectories = true;
	_fileSystemWatcher.EnableRaisingEvents = true;
