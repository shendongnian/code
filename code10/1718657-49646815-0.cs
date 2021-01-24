    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TileManager : MonoBehaviour {
    
        public GameObject tilePrefab;
    
        [Serializable]
        public class Tile {
            public int tileID;
            public string tileName;
            public Sprite tileSprite;
            public float breakSpeed;
        }
    
        // List should be populated in inspector
        public List<Tile> Tiles;
    
        public GameObject Generate(int id) {
            GameObject newObj = null;
            try {
    
                var data = Tiles.FirstOrDefault(tileData => id == tileData.tileID);
                newObj = Instantiate(tilePrefab);
                newObj.GetComponent<SpriteRenderer>().sprite = data.tileSprite;
                newObj.name = data.tileName; // same name to multiple tiles?
            } catch {
                Debug.LogWarning("TileManager not initialised properly!");
            }
            return newObj;
        }
    }
