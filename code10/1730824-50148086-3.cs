    var typeOfItem = typeof(Item);
    var argParam = Expression.Parameter(typeOfItem, "x");
    var itemIdProperty = Expression.Property(argParam, "ItemId");
    
    var properties = typeOfItem.GetProperties();
    Expression descriptionProperty;
    if (settings < properties.Count())            
        descriptionProperty = Expression.Property(argParam, properties[settings].Name);
    else
        descriptionProperty = Expression.Constant(string.Empty);
    
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
    return _repo.GetAsQueryable<Item>().Select(lambda);
