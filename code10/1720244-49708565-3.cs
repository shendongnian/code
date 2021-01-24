    public static class DataModelExtensions
    {
        public static ParentItemApiModel ToApiModel(this ParentItemDataModel dataModel)
        {
            return new ParentItemApiModel
            {
                Id = dataModel.Id,
                SomeInfo = dataModel.SomeInfo
            };
        }
    }
