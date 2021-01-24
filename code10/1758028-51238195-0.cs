    public static async Task<String> getGallery()
		{
			var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
			if (storageStatus != PermissionStatus.Granted)
			{
				try
				{
					var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
					storageStatus = results[Permission.Storage];
				}
				catch (Exception ex)
				{
					Debug.WriteLine(@"ERROR {0}", ex.Message);
					return null;
				}
			}
			if (storageStatus == PermissionStatus.Granted)
			{
				//Solution for straight base64 conversion
				try
				{
					var media = CrossMedia.Current;
					//var file;
					MediaFile file = null;
					if (CrossMedia.Current.IsPickPhotoSupported)
					{
						await media.PickPhotoAsync(new PickMediaOptions
						{
							PhotoSize = PhotoSize.Medium,
							CompressionQuality = 50
						}).ContinueWith(t =>
						{
							if (!t.IsCanceled)
								file = t.Result;
						}, TaskScheduler.FromCurrentSynchronizationContext());
					}
					else
					{
						MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert()
						{
							Title = MessageConsts.WarnTitle,
							Message = MessageConsts.GallCamPermNotAvail,
							Cancel = MessageConsts.BtnOk
						});
					}
					String base64 = null;
					if (file != null)
						base64 = await toBase64(file);
					return base64;
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.StackTrace);
				}
				return null;
			}
			else
			{
				MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert()
				{
					Title = MessageConsts.WarnTitle,
					Message = MessageConsts.GallCamPermNotAvail,
					Cancel = MessageConsts.BtnOk
				});
				//On iOS you may want to send your user to the settings screen.
				if (Device.RuntimePlatform == Device.iOS)
					CrossPermissions.Current.OpenAppSettings();
			}
			return null;
		}
