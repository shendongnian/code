    public class Email
    {
        const int MaxAttachments = /* ... */;
    
        public Email(/* ... */)
        {
            this.Attachments = new FixedSizeList<Attachment>(MaxAttachments);
        }
    
        // ...
    
        public IList<Attachment> Attachments
        {
            get;
            private set;
        }
    }
    
    class FixedSizeList<T> : IList<T>
    {
        List<T> innerList;
        int maxCount;
    
        public FixedSizeList(int maxCount)
        {
            this.innerList = new List<T>(maxCount);
            this.maxCount = maxCount;
        }
    
        // override all the IList<T> members here by delegating
        // to your innerList ...
        // ...
    
        public void Add(T item)
        {
             if (this.Count > this.maxSize)
             {
                 throw new InvalidOperationException("No more items can be added.");
             }
    
             this.innerList.Add(item);
        }
    
        // ...
        // ...
    }
