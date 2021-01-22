    Dictionary<Type, List<Room>> rooms = new Dictionary<Type, List<Room>>;
    
    void Main(){
      KitchenRoom kr = new KitchenRoom();
      DummyRoom dr = new DummyRoom();
      RoomType1 rt1 = new RoomType1();
      ... 
    
      AddRoom(kr);
      AddRoom(dr);
      AddRoom(rt1);
      ...
    
    }
    
    void AddRoom(Room r){
      Type roomtype = r.GetType();
      if(!rooms.ContainsKey(roomtype){ //If the type is new, then add it with an empty list
       rooms.Add(roomtype, new List<Room>);
      }
      //And of course add the room.
      rooms[roomtype].Add(r);
    }
