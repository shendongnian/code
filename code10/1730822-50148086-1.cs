    var typeOfItem = typeof(Item);
    var argParam = Expression.Parameter(typeOfItem, "x");
    var itemIdProperty = Expression.Property(argParam, "ItemId");
    
    var propertyName = typeOfItem.GetProperties()[setting].Name;
    var descriptionProperty = Expression.Property(argParam, propertyName);
    
    var ItemDTOType = typeof(ItemDTO);
    
    var newInstance = Expression.MemberInit(
        Expression.New(ItemDTOType),
        new List<MemberBinding>()
        {
            Expression.Bind(ItemDTOType.GetMember("Id")[0], itemIdProperty),
            Expression.Bind(ItemDTOType.GetMember("DisplayName")[0], descriptionProperty),
        }
    );
    
    var lambda = Expression.Lambda<Func<Item, ItemDTO>>(newInstance, argParam);
