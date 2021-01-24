    public VarRecipeEntryMapping()
    {
        Table("var_recipe_entry");
        // ...
        ManyToOne(x => x.Recipe, m =>
        {
            m.Column("var_recipe_id");
            m.NotNullable(true);
        });
    }
