        public virtual ICollection<TKey> Keys
        {
            get
            {
                using (new ReadOnlyLock(this.dictionaryLock))
                {
                    return new List<TKey>(this.dict.Keys);
                }
            }
        }
        public virtual ICollection<TValue> Values
        {
            get
            {
                using (new ReadOnlyLock(this.dictionaryLock))
                {
                    return new List<TValue>(this.dict.Values);
                }
            }
        }
