    public class FixedSizeList<T> : Collection<T>
    {
        public int MaxItems {get;set;}
        public new void Add(T item){
            while (base.Count >= MaxItems)
                base.RemoveAt(0);
            }
            base.Add(item);
        }
    }
