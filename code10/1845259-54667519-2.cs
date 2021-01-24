    public VarRecipeMapping()
    {
        Table("var_recipe");
        // ...
        Bag(x => x.Entries, m =>
        {
            // The custom name needs to be specified here too
            m.Key(n => {
                n.Column("var_recipe_id");
            });
            m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            m.Lazy(CollectionLazy.NoLazy);
        },
        a => a.OneToMany());
    }
