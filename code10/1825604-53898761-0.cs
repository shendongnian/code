    class Room : IEnumerable<RoomItems>
    {
        List<RoomItems> items = new List<RoomItems>();
    
        public void Add(RoomItems item)
        {
            items.Add(item);
        }
    
        public IEnumerator<RoomItems> GetEnumerator()
        {
            return items.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
