    StandardRoom stdRoom = _floor.GetRoomByIndex(CheckActiveRoomIndex()) as StandardRoom;
    if ( stdRoom != null )
    {
      for (int i = 0; i < stdRoom.enemies.Count; i++)
      {
          stdRoom.enemies[i].UpdateBoundingBox();
      }
    }
