    public static U ParentToChild<T, U>(this T parent) where U : T {
        //                                            ^^^^^^^^^^^^^
        var serializedParent = JsonConvert.SerializeObject(parent);
        return JsonConvert.DeserializeObject<U>(serializedParent);
    }
