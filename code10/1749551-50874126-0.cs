        public void addTaggedValueType(string tagName, string tagDescription, string tagDetail)
        {
            global::EA.PropertyType taggedValueType = (global::EA.PropertyType)myEARepository.PropertyTypes.AddNew(tagName, "");
            taggedValueType.Description = tagDescription;
            taggedValueType.Detail = tagDetail;
            taggedValueType.Update();
        }
