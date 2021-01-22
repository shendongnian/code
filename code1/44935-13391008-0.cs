    string className = entityObject.GetType().Name;
    var container = _DbContext.MetadataWorkspace.GetEntityContainer(_DbContext.DefaultContainerName, DataSpace.CSpace);
    string setName = (from meta in container.BaseEntitySets
                      where meta.ElementType.Name == className
                      select meta.Name).First();
    _DbContext.AttachTo(setName, entityObject);
