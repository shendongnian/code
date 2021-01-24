	public T GetSimpleModelFromMultiNode<T> (FicheArticleViewModel model, string alias) where T: INomAndId, new()
    {
        var listeItems = CurrentPage.GetPropertyValue<IEnumerable<IPublishedContent>>(alias);
        var result = new T();
        if (!CurrentPage.HasValue(alias)) return result;
        foreach (var item in listeItems)
        {
            result.Id = item.Id.ToString();
            result.Nom = item.Name;
        }
        return result;
    }
