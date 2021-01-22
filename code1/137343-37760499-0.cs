    public class FromToRange<T>
        {
            public T From { get; set; }
            public T To { get; set; }
    
            public FromToRange()
            {
            }
    
            public FromToRange(T  from, T  to)
            {
                this.From = from;
                this.To = to;
            }
            public override string ToString()
            {
                string sRet = String.Format("From {0} to {1}", From, To);
                return sRet;
            }
            public override bool Equals(object obj)
            {
                if (this == obj) return true;
                FromToRange<T> pair = obj as FromToRange<T>;
                if (pair == null) return false;
                return Equals(From, pair.From) && Equals(To, pair.To);
            }
    
            public override int GetHashCode()
            {
                return (From != null ? From.GetHashCode() : 0) + 29 * (To != null ? To.GetHashCode() : 0);
            }
    
        }
