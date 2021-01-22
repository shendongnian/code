    public static TProperty GetPropertyOrDefault<TObject, TProperty>(this TObject model, Func<TObject, TProperty> valueFunc)  
                                                            where TObject : class
        {
            try
            {
                return valueFunc.Invoke(model);
            }
            catch (NullReferenceException nex)
            {
                return default(TProperty);
            }
        }
