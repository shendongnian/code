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
            asset.JobID = hit.Fields.Values<SearchAsset, long>(f => f.JobID).FirstOrDefault();
            asset.FolderID = hit.Fields.Values<SearchAsset, long>(f => f.JobFolderID).FirstOrDefault();
            asset.PlusRating = hit.Fields.Values<SearchAsset, long>(f => f.Rating).FirstOrDefault();
            asset.Select = hit.Fields.Values<SearchAsset, bool>(f => f.Selected).FirstOrDefault();
            asset.Alt = hit.Fields.Values<SearchAsset, bool>(f => f.Alted).FirstOrDefault();
            asset.Approve = hit.Fields.Values<SearchAsset, bool>(f => f.Approved).FirstOrDefault();
            asset.Kill = hit.Fields.Values<SearchAsset, bool>(f => f.Killed).FirstOrDefault();
            asset.Flag = ConvertNullEnumerable(hit.Fields.Values<SearchAsset, long>(f => f.UserFlags.Find(u => u == userID))).Contains(userID);
            asset.Color = (AssetColorCd)hit.Fields.Values<SearchAsset, long>(f => f.Color).FirstOrDefault();
            asset.FileExtension = ConvertNullEnumerable(hit.Fields.Values<SearchAsset, string>(f => f.Extensions.FirstOrDefault())).FirstOrDefault();
            asset.OriginalType = assetTypesManager.Restore(ConvertNullEnumerable(hit.Fields.Values<SearchAsset, string>(f => f.OriginalTypeCd)).FirstOrDefault());
            asset.NoteCount = hit.Fields.Values<SearchAsset, int>(f => f.NoteCount).FirstOrDefault();
            asset.Status = (AssetStatus)hit.Fields.Values<SearchAsset, long>(f => f.Status).FirstOrDefault();
            asset.ClosedGalleryCount = hit.Fields.Values<SearchAsset, int>(f => f.ClosedGalleryCount).FirstOrDefault();
            asset.Finalized = hit.Fields.Values<SearchAsset, bool>(f => f.Finalized).FirstOrDefault();
            asset.TotalGalleryCount = hit.Fields.Values<SearchAsset, int>(f => f.TotalGalleryCount).FirstOrDefault();
            asset.Width = hit.Fields.Values<SearchAsset, int>(f => f.Width).FirstOrDefault();
            asset.Height = hit.Fields.Values<SearchAsset, int>(f => f.Height).FirstOrDefault();
            asset.PageCount = hit.Fields.Values<SearchAsset, int>(f => f.PageCount).FirstOrDefault();
            asset.ByteCount = hit.Fields.Values<SearchAsset, long>(f => f.ByteCount).FirstOrDefault();
            asset.HasMarkup = hit.Fields.Values<SearchAsset, bool>(f => f.HasMarkup).FirstOrDefault();
            asset.StorageFolderPath = ConvertNullEnumerable(hit.Fields.Values<SearchAsset, string>(f => f.StorageFolderPath)).FirstOrDefault();
            asset.NewStorageLocation = ConvertNullEnumerable(hit.Fields.Values<SearchAsset, bool>(f => f.NewStorageLocation)).FirstOrDefault();
            asset.Archived = ConvertNullEnumerable(hit.Fields.Values<SearchAsset, bool>(f => f.Archived)).FirstOrDefault();
            if (hit.Source != null && hit.Source.Lightboxes != null && hit.Source.Lightboxes.Count > 0)
            {
                asset.LightboxAsset = new LightboxAsset()
                {
                    AddedBy = hit.Source.Lightboxes.First().AddedBy,
                    AssetID = asset.ID,
                    LightboxID = hit.Source.Lightboxes.First().LightboxID,
                    SeqOrder = hit.Source.Lightboxes.First().OrderID
                };
            }
            return asset;
        }
    }
