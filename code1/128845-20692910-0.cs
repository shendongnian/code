    Type genericTypeParameter = Type.GetType(string.Format("Gestor.Data.Entities.{0}, Gestor.Data", e.Item.Value));
    MetaDataUtil someInstance = new MetaDataUtil();
    var returnResult =
        typeof(MetaDataUtil)
        .GetMethod("GetColumnsAsGrid")
        .MakeGenericMethod(new [] { genericTypeParameter })
        .Invoke(someInstance, null);//passing someInstance here because we want to call someInstance.GetColumnsAsGrid<...>()
