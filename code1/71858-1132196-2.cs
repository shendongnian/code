    public void StoreUsingKey<T>(T value) where T : class, new() {
                    if (idModel is IIDModel)
                            Store<T>((IIDModel)idModel);
    
                    AddToCacheUsingKey(value);
            }
