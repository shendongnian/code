    public readonly struct TModelItem
    {
        public int Integer { get; }
        public TModelItem(int integer)
        {
            Integer = integer;
        }
        public static implicit operator TModelItem(int integer)
        {
            return new TModelItem(integer);
        }
        public static implicit operator int(TModelItem tModelItem)
        {
            return tModelItem.Integer;
        }
    }
