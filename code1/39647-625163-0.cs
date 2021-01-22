    public IEnumerable<Model> Models
    {
        get
        {
            foreach (Model mod in this._models)
                yield return new Model(mod);
        }
    }
