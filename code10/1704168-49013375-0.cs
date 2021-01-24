	var videoURL = NSUrl.FromString(urlString);
	var videoPath = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0];
	NSUrlSession.SharedSession.CreateDownloadTask(videoURL, (location, response, createTaskError) =>
	{
		if (location != null && createTaskError == null)
		{
			var destinationURL = videoPath.Append(response?.SuggestedFilename ?? videoURL.LastPathComponent, false);
			// If file exists, it is already downloaded, but for debugging, delete it...
			if (NSFileManager.DefaultManager.FileExists(destinationURL.Path)) NSFileManager.DefaultManager.Remove(destinationURL, out var deleteError);
			NSFileManager.DefaultManager.Move(location, destinationURL, out var moveError);
			if (moveError == null)
			{
				PHPhotoLibrary.RequestAuthorization((status) =>
				{
					if (status.HasFlag(PHAuthorizationStatus.Authorized))
					{
						PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
						{
							PHAssetChangeRequest.FromVideo(destinationURL);
						}, (complete, requestError) =>
						 {
							if (!complete && requestError != null)
								Console.WriteLine(requestError);
						 });
					}
				});
			}
			else
				Console.WriteLine(moveError);
		}
		else
			Console.WriteLine(createTaskError);
	}).Resume();
