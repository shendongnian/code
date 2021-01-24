		private async void SaveAsync(IFormFile file)
		{
			CloudBlockBlob blob = this.blobContainer.GetBlockBlobReference(file.FileName);
			var task = blob.UploadFromStreamAsync(file.OpenReadStream(), file.Length);
			while (task.IsCompleted == false) {
				Thread.Sleep(1000);
			}
		}
