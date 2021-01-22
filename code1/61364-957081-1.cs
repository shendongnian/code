    int tileNumber = GetTile(x,y);
    if  (tileNumber != -1)
    {
       ... use tileNumber ...
    }
    int? result = GetTile(x,y);
    if (result.HasValue)
    {
        int tileNumber = result.Value; 
       ... use tileNumber ...
    }
    Tile tile = GetTile(x,y);
    if (tile != null)
    {
       ... use tile ...
    }
