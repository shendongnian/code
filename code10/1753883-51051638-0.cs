    public void SomeMethod(int number)
    {
        if (this._dictionary.TryGetValue(number, out var item))
        {
            var (isTrue, timestamp) = item;
        }
    }
