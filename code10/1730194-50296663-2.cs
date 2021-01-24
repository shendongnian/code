    public class FullFieldSelectors : FilenameFieldSelectors
    {
        private readonly AssetTypesManager assetTypesManager;
        private readonly long userID;
        public FullFieldSelectors(long userID)
        {
            assetTypesManager = new AssetTypesManager();
            this.userID = userID;
        }
        public override Asset ConvertToAsset(IHit<SearchAsset> hit)
        {
            var asset = base.ConvertToAsset(hit);
            var searchAsset = hit.Source;
            asset.JobID = searchAsset.JobID;
            asset.FolderID = searchAsset.JobFolderID;
            asset.PlusRating = searchAsset.Rating;
            asset.Select = searchAsset.Selected;
            asset.Alt = searchAsset.Alted;
            asset.Approve = searchAsset.Approved;
            asset.Kill = searchAsset.Killed;
            asset.Flag = searchAsset.UserFlags != null && searchAsset.UserFlags.Contains(userID);
            asset.Color = (AssetColorCd)searchAsset.Color;
            asset.FileExtension = string.Empty;
            if (searchAsset.Extensions != null && searchAsset.Extensions.Any())
                asset.FileExtension = searchAsset.Extensions.First();
            asset.OriginalType = assetTypesManager.Restore(searchAsset.OriginalTypeCd);
            asset.NoteCount = searchAsset.NoteCount;
            asset.Status = (AssetStatus)searchAsset.Status;
            asset.ClosedGalleryCount = searchAsset.ClosedGalleryCount;
            asset.Finalized = searchAsset.Finalized;
            asset.TotalGalleryCount = searchAsset.TotalGalleryCount;
            asset.Width = searchAsset.Width;
            asset.Height = searchAsset.Height;
            asset.PageCount = searchAsset.PageCount;
            asset.ByteCount = searchAsset.ByteCount;
            asset.HasMarkup = searchAsset.HasMarkup;
            asset.StorageFolderPath = searchAsset.StorageFolderPath ?? string.Empty;
            asset.NewStorageLocation = searchAsset.NewStorageLocation;
            asset.Archived = searchAsset.Archived;
            if (searchAsset.Lightboxes != null && searchAsset.Lightboxes.Any())
            {
                var searchLightbox = searchAsset.Lightboxes.First();
                asset.LightboxAsset = new LightboxAsset()
                {
                    AddedBy = searchLightbox.AddedBy,
                    AssetID = asset.ID,
                    LightboxID = searchLightbox.LightboxID,
                    SeqOrder = searchLightbox.OrderID
                };
            }
            return asset;
        }
    }
