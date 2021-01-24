    public TEntity GetById(object id){
        var entity = connection.Get<TEntity>(id);
        if (entity is ITranslatable t)
        {
            t.Translator = _translationService;
        }
        return entity;
    }
