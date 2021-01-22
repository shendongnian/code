    void AddRoom(Room r, IList<Room> rooms, IDictionary<string, bool> roomTypes)
    {
       if (!roomTypes.Contains(r.RoomType))
       {
          rooms.Add(r);
          roomTypes.Add(r.RoomType, true);
       }
    }
