		public void AddOne( T file )
		{
			file.id = Guid.NewGuid().ToString();
			Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blob = _AzureBlobCollection.BlobDirectory.GetBlockBlobReference( file.id );
			blob.UploadFromStream( file.Data );
			blob.Metadata.Add( "data", JsonConvert.SerializeObject( file ) );
			blob.SetMetadata();
		}
