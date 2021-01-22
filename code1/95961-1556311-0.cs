    protected void Require<TValidator, TParam>(
        TValidator validator, 
        Expression<Func<TValidator, TParam>> property, 
        Expression<Predicate<TParam>> predicateExpression)
    {
        var propertyValue = property.Compile().Invoke(validator);
        Predicat<TParam> predicate = predicateExpression.Compile();        
        if(!predicate.Invoke(propertyValue))
        {    
            throw new ValidatorInitializationException(
                "Error while initializing validator: " + predicateExpression,
                GetType());
        }
    }
