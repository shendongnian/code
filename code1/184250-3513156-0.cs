    List<string> ToStringList<T>(this IEnumerable<T> list)
    {
        list.Select(obj => obj.ToString()).ToList();
    }
    List<Core.Room> coreRoomList = ... 
    List<Core.Hotel> coreHotelList = ... 
    List<List<string>> ListofLists = new List<List<string>> ();
    ListofLists.Add(coreRoomList.ToStringList());
    ListofLists.Add(coreHotelList.ToStringList());
