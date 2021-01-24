    /// <summary>
    /// Make a datastore key given a item's id.
    /// </summary>
    /// <param name="id">An Item's id.</param>
    /// <returns>A datastore key.</returns>
    public static Key ToKey(this long id) =>
        new Key().WithElement("Item", id);
    /// <summary>
    /// Make a id given a datastore key.
    /// </summary>
    /// <param name="key">A datastore key</param>
    /// <returns>A item id.</returns>
    public static long ToId(this Key key) => key.Path.First().Id;
    /// <summary>
    /// Create a datastore entity with the same values as item.
    /// </summary>
    /// <param name="item">The item to store in datastore.</param>
    /// <returns>A datastore entity.</returns>
    public static Entity ToEntity(this Item item) => new Entity()
    {
        Key = item.Id.ToKey(),
        ["Name"] = item.Name,
        ["Price"] = item.Price,
    };
    
    /// <summary>
    /// Unpack an itemfrom a datastore entity.
    /// </summary>
    /// <param name="entity">An entity retrieved from datastore.</param>
    /// <returns>An Item.</returns>
    public static Item ToItem(this Entity entity) => new Item() {
        Id = entity.Key.Path.First().Id,
        Name = (string)entity["Name"],
        Price = (decimal)entity["Price"]
    };
