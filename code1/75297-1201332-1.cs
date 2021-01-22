        private static DTOConversionResults ConvertDTOToEntity(DataTransferObject transferObject,object parent)
        {
            DTOConversionResults conversionResults = new DTOConversionResults();
            object baseEntity = null;
            ObjectHandle entity = Activator.CreateInstance(transferObject.AssemblyName,
                                                           transferObject.TransferType);
            if (entity != null)
            {
                baseEntity = entity.Unwrap();
                conversionResults.Add(UpdatePrimaryKeyValue(transferObject, baseEntity));
                conversionResults.Add(UpdateFieldValues(transferObject, baseEntity));
                conversionResults.Add(UpdatePropertyValues(transferObject, baseEntity));
                conversionResults.Add(UpdateSubEntitiesValues(transferObject, baseEntity));
                conversionResults.Add(UpdateRelatedEntitiesValues(transferObject, baseEntity,parent));
    ....
        private static DTOConversionResult UpdatePropertyValues(DataTransferObject transferObject, object entity)
        {            
            DTOConversionResult conversionResult = new DTOConversionResult();
            foreach (KeyValuePair<string, object> values in transferObject.PropertyValues)
            {
                try
                {
                    ReflectionHelper.SetPropertyValue(entity, values.Key, values.Value);
                }
                catch (Exception ex)
                {
                    string failureReason = "Failed to set property " + values.Key + " value " + values.Value;
                    conversionResult.Failed = true;
                    conversionResult.FailureReason = failureReason;
                    Logger.LogError(failureReason);
                    Logger.LogError(ExceptionLogger.BuildExceptionLog(ex));
                }
            }
            return conversionResult;
        }
