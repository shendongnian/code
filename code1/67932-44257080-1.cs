    public static string GetoptionsetText(string entityName, string attributeName, int optionSetValue, IOrganizationService service)
        {
                     string AttributeName = attributeName;
            string EntityLogicalName = entityName;
            RetrieveEntityRequest retrieveDetails = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.All,
                LogicalName = entityName
            };
            RetrieveEntityResponse retrieveEntityResponseObj = (RetrieveEntityResponse)service.Execute(retrieveDetails);
            Microsoft.Xrm.Sdk.Metadata.EntityMetadata metadata = retrieveEntityResponseObj.EntityMetadata;
            Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata picklistMetadata = metadata.Attributes.FirstOrDefault(attribute => String.Equals(attribute.LogicalName, attributeName, StringComparison.OrdinalIgnoreCase)) as Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata;
            Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata options = picklistMetadata.OptionSet;
    
            IList<OptionMetadata> OptionsList = (from o in options.Options
                                                 where o.Value.Value == optionSetValue
                                                 select o).ToList();
            string optionsetLabel = (OptionsList.First()).Label.UserLocalizedLabel.Label;
            return optionsetLabel;
        }
