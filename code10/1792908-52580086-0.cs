    public class yield
    {
    }
    ...
    public IEnumerable<yield> GetInts()
    {
        yield item;
        item = new yield(); //compiler complains - item not declared.
        
        yield item2 = new yield(); //compiler complains-item2 not declared.
    }
