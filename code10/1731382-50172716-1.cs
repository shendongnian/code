     if (string.isNullOrEmpty(AssetNumber) && AssetCategoryId == 0) {
                status = Status.ReportWarning("Invalid Entry.");
            }
            else {
                var assetsData = assetsRepo.FindAll(x => ((!string.isNullOrEmpty(AssetNumber) && AssetCategoryId != 0 && x.AssetCategoryId == AssetCategoryId && x.AssetNumber == AssetNumber)
                    || (string.isNullOrEmpty(AssetNumber) && AssetCategoryId != 0 && x.AssetCategoryId == AssetCategoryId)
                    || (!string.isNullOrEmpty(AssetNumber) && AssetCategoryId == 0 && x.AssetNumber == AssetNumber)), x => x.AssetCategory).ToList();
                status = Status.ReportSuccess("Data Retrieved Successfully.");
                status.Data = assetsData;
            }
