            public enum Projects
        {
            Hotels = 1,
            Homes = 2,
            Hotel_Home = 3
        }
    
    
    int projectId = rRoom.GetBy(x => x.RoomId == room.RoomId).FirstOrDefault().ProjectId.TryToInt32();
    Projects Project = (Projects)projectId;
