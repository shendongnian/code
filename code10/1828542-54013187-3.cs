	private async void GetPhotos(Intent data)
	{
		var placePicked = PlacePicker.GetPlace(this, data);
		string placeId = placePicked.Id;
		using (var photoMetadataResponse = await mGeoDataClient.GetPlacePhotosAsync(placeId))
		using (var photoMetadataBuffer = photoMetadataResponse.PhotoMetadata)
		{
			foreach (var item in photoMetadataBuffer)
			{
				using (var photoResponse = await mGeoDataClient.GetPhotoAsync(item))
				{
					var bitmap = photoResponse.Bitmap;
					photoResponse.Dispose();
				}
				break;
			}
		}
	}
