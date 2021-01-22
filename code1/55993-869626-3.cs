    public void Woof(object resource)
    {
        if (resource == null)
        {
            throw new ArgumentNullException(infoof(resource));
        }
        // ..
    }
