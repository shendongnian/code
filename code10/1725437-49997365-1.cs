    public static object MapEntity(object entityInstance)
       {
            var typeEntity = entityInstance.GetType();
            var typeMetaDataEntity = Type.GetType(typeEntity.FullName + "MetaData");
            if (typeMetaDataEntity == null)
                throw new Exception();
            var metaDataEntityInstance = Activator.CreateInstance(typeMetaDataEntity);
            foreach (var property in typeMetaDataEntity.GetProperties())
            {
                if (typeEntity.GetProperty(property.Name) == null)
                    throw new Exception();
                property.SetValue(
                    metaDataEntityInstance,
                    typeEntity.GetProperty(property.Name).GetValue(entityInstance));
            }
            return metaDataEntityInstance;
        }
