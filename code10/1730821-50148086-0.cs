    var ArgParam = Expression.Parameter(typeof(Item), "x");
    var ItemIdProperty = Expression.Property(argParam, "ItemId");
    
    var nameOfDescriptionProperty = getName(setting);
    var DescriptionProperty = Expression.Property(argParam, nameOfDescriptionProperty);
    
    var ItemDTOType = typeof(ItemDTO);
    
    var newInstance = Expression.MemberInit(
    	Expression.New(ItemDTOType),
    	new List<MemberBinding>() {
    		Expression.Bind(ItemDTOType.GetMember("Id")[0], ItemIdProperty),
    		Expression.Bind(ItemDTOType.GetMember("DisplayName")[0], DescriptionProperty),
    	}
    );
    
    var lambda = Expression.Lambda<Func<Item, ItemDTO>>(newInstance, ArgParam);
