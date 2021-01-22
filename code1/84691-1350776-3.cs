        public static TList Append<TList, TValue>(
            this TList list, TValue item) where TList : ICollection<TValue>
        {
            if(list == null) throw new ArgumentNullException("list");
            list.Add(item);
            return list;
        }
        ...
        List<int> list = new List<int>().Append(1).Append(2).Append(3);
