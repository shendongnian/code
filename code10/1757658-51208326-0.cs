    public static U ParentToChild<U>(this object parent) {
        // note how I used "parent.GetType()" instead of `typeof(T)`
        if (!typeof(U).IsSubclassOf(parent.GetType()))
            throw new Exception(typeof(U).Name + " isn't a subclass of " + parent.GetType().Name);
        var serializedParent = JsonConvert.SerializeObject(parent);
        return JsonConvert.DeserializeObject<U>(serializedParent);
    }
