    using UnityEngine;
    using UnityEngine.Tilemaps;
    public class test : MonoBehaviour {
       //You need references to to the Grid and the Tilemap
       Tilemap tm;
       Grid gd;
       void Start() {
           //This is probably not the best way to get references to
           //these objects but it works for this example
           gd = FindObjectOfType<Grid>();
           tm = FindObjectOfType<Tilemap>();
       }
       void Update() {
           if (Input.GetMouseButtonDown(0)) {
               Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
               Vector3Int posInt = gd.LocalToCell(pos);
               //Shows the cell reference for the grid
               Debug.Log(posInt);
               Debug.Log(tm.GetTile(posInt).name);
           }
       }
    }
