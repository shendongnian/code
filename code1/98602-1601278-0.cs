    public IEnumerator<Order> GetEnumerator()
    {
        yield return this; // You need to create an ACTUAL enumerator here!
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator(); // This can call the above, since IEnumerator<Order> is also IEnumerator
    }
