		var fetchOptions = new PHFetchOptions();
		PHFetchResult allPhotos = PHAsset.FetchAssets(PHAssetMediaType.Image, fetchOptions);
		_numberofImg = allPhotos.Count;
		Debug.WriteLine("Total img no + " + _numberofImg);
		await Task.Yield();
		await Task.Run(() => ImgProcess(allPhotos));
		return true;
	private void ImgProcess(PHFetchResult allPhotos)
	{
		//await Task.Run(() =>
		//{
			for (nint i = 0; i < allPhotos.Count; i++)
			{
				Debug.WriteLine("Starting " + i);
				var phasset = allPhotos[i] as PHAsset;
				var options = new PHImageRequestOptions()
				{
					Synchronous = true,
					NetworkAccessAllowed = false,
					DeliveryMode = PHImageRequestOptionsDeliveryMode.FastFormat
				};
				PHImageManager.DefaultManager.RequestImageData(phasset, options, ComplManager);
			}
		//});
		//return;
	}
