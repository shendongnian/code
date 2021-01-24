    if (mapClass.Maps[3].Count != 0)
    {
        mapClass.ClearMap(); // CollisionTiles.Clear(); BackGroundTiles.Clear();
        mapClass.CollisionTiles = new List<CollisionTiles>(mapClass.Maps[3]);
        mapClass.BackgroudTiles = new List<BackgroudTiles>(mapClass.SpriteMaps[3]);
    }
    else // this is the only other option from the above if
    {
        mapClass.GenerateCustomMap(64, 10, 8, 3, false);
    }
