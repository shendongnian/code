    public IEnumerable<Model> Models
    {
        get
        {
            foreach (Model mod in this._models)
                yield return new Model(mod);
            // equivalent to:
            // return _models.Select(m => new Model(m));
            // as per Jon's comment
        }
    }
