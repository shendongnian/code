	internal IObservable<BlobItem> GetFilesAsEnumerable(CloudBlobContainer container, string directoryName, bool recursive)
	{
		return GetFiles(container, directoryName, recursive).ToEnumerable();
	}
	
	internal IObservable<BlobItem> GetFiles(CloudBlobContainer container, string directoryName, bool recursive)
	{
		return Observable.Create<BlobItem>(async obs =>
			{
				BlobContinuationToken continuationToken = null;
				do
				{
					var response = container.GetDirectoryReference(directoryName).ListBlobsSegmentedAsync(/*useFlatBlobListing*/ recursive, BlobListingDetails.None, 100, continuationToken, null, null).GetAwaiter().GetResult();
					continuationToken = response.ContinuationToken;
					foreach (var item in response.Results)
					{
						// Only required if recursive == false
						if (item.GetType() != typeof(CloudBlobDirectory))
							obs.OnNext(new BlobItem(item));
					}
				}
				while (continuationToken != null);
			});
	}
