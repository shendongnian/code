    private Point blueSpawn, redSpawn;
            //this the method for your question
             private void SpawnPortals()
                {
                    //Spawns the blue portal
                    blueSpawn = new Point(0, 0);
                    GameObject tmp = (GameObject)Instantiate(bluePortalPrefab, Tiles[BlueSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
                    
            
                    //Spawns the red portal
                    redSpawn = new Point(11, 6);
                    Instantiate(redPortalPrefab, Tiles[redSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
                }
