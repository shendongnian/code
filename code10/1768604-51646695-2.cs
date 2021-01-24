    public Task<Animal[]> GetAnimalsFromServer<T>() where T : Animal, new()
    {
        if (typeof(Bird).IsAssignableFrom(typeof(T)))
        {
            var method = GetType().GetMethod(nameof(GetBirdsFromServer));
            var generic = method.MakeGenericMethod(typeof(T));
            var result = generic.Invoke(this, new object[] { });
            return (result as Task<Bird[]>)
                        .ContinueWith(x => x.Result.Cast<Animal>().ToArray());
        }
        //other similar code
    }
    
    public Task<Bird[]> GetBirdsFromServer<T>() where T : Bird, new()
    {
        // Bird specific functionality here.
        if (typeof(T) == typeof(Pelican))
        {
            return _serverConnection.GetPelicansFromServer()
                        .ContinueWith(x => x.Result.Cast<Bird>().ToArray());
        }
        //other similar code
    }
