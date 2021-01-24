    using UnityEngine;
    using UnityEngine.Tilemaps;
    
    public class MouseManager : MonoBehaviour
    {
    
    private Tilemap tilemap;
    
    void Start()
    {
        //You can serialize this and assign it in the editor instead
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = tilemap.WorldToCell(mousePos);
            if (tilemap.HasTile(gridPos))
                Debug.Log("Hello World from " + gridPos);
        }
    }
    }
