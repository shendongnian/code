    [RequireComponent(typeof(SpriteRenderer))]
    public class TileObject : MonoBehaviour {
        private SpriteRenderer myRenderer;
        private void Awake() {
            myRenderer = getComponent<SpriteRenderer>();
        }
    
        void Update()
        {
            if(Mathf.Abs(transform.position.x - Camera.main.transform.position.x) > SpawnTileBoundry.HorizontalExtents || Mathf.Abs(transform.position.y - Camera.main.transform.position.y) > SpawnTileBoundry.VerticalExtents) 
            {
                // With this check the tile knows it is no longer visible,
                // I could have used OnBecameInvisible to handle this
                // but I added a threshold to the extents, that prevent it so
                // players would see tiles "appearing" this caused a nice bug, where
                // if you moved just right a row/col of tiles wouldn't spawn.
                WorldManager.instance.EnqueTile(this);
            }
        }
    
        public void UpdateSprite(Sprite sprite)
        {
            myRenderer.sprite = sprite;
        }
    
        public void UpdateSprite(Sprite sprite, float grayColor)
        {
             UpdateSprite(sprite);
             myRenderer.color = new Color(grayColor,grayColor,grayColor,1f);
        }
    }
