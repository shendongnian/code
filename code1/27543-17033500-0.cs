    public ActionResult Index(string i, int? groupId, int? itemId)
    {
        if (!string.IsNullOrWhitespace(i))
        {
            // parse i for the id
        }
        else if (groupId.HasValue && itemId.HasValue)
        {
            // use groupId and itemId for the id
        }
    }
