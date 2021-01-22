    [DataContract]
    public class DataTransferObject
    {
        private Dictionary<string, object> propertyValues = new Dictionary<string, object>();
        private Dictionary<string, object> fieldValues = new Dictionary<string, object>();
        private Dictionary<string, object> relatedEntitiesValues = new Dictionary<string, object>();
        private Dictionary<string, object> primaryKey = new Dictionary<string, object>();
        private Dictionary<string,List<DataTransferObject>> subEntities = new Dictionary<string, List<DataTransferObject>>();
    ...
        public static DataTransferObject ConvertEntityToDTO(object entity,Type transferType)
        {
            DataTransferObject dto = new DataTransferObject();
            string[] typePieces = transferType.AssemblyQualifiedName.Split(',');
            dto.AssemblyName = typePieces[1];
            dto.TransferType = typePieces[0];
            CollectPrimaryKeyOnDTO(dto, entity);
            CollectPropertiesOnDTO(dto, entity);
            CollectFieldsOnDTO(dto, entity);
            CollectSubEntitiesOnDTO(dto, entity);
            CollectRelatedEntitiesOnDTO(dto, entity);
            return dto;
        }
    ....
         private static void CollectPropertiesOnDTO(DataTransferObject dto, object entity)
        {
            List<PropertyInfo> transferProperties = ReflectionHelper.GetProperties(entity,typeof(PropertyAttribute));
            CollectPropertiesBasedOnFields(entity, transferProperties);
            foreach (PropertyInfo property in transferProperties)
            {
                object propertyValue = ReflectionHelper.GetPropertyValue(entity, property.Name);
                
                dto.PropertyValues.Add(property.Name, propertyValue);
            }
        }
