    public void SomeMethod(int number)
    {
        if (this._dictionary.TryGetValue(number, out var item))
        {
            // use item.isTrue;
            // use item.timestamp;
        }
    }
