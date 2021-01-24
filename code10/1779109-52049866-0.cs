    StartCoroutine(DeleteTiles());
    ...
    private IEnumerator DeleteTiles() {
        BoundsInt bounds = Lvl1.cellBounds;
        TileBase[] allTiles = Lvl1.GetTilesBlock(bounds);
    
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    Lvl1.SetTile(new Vector3Int(x, y, 0), null);
                    yield return new WaitForSeconds(1); //or however long
                }
                else
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        }
    }
