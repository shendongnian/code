        private static IEnumerable<AssetDataModel> GetAllDataForAsset(AssetModel asset)
        {
            dynamic apiResponse = new ApiRequestUtility().DownloadFromApi(optiAssetDataWithinRangeUrl);
            for (var index = 0; index != apiResponse.Items.Count; index++)
                yield return new AssetDataModel
                {
                    Id = apiResponse["Items"][index].id,
                    ResourceId = apiResponse["Items"][index].value[0].resourceId,
                    Timestamp = apiResponse["Items"][index].timeValue,
                    Value = apiResponse["Items"][index].value[0].value
                };
        }
