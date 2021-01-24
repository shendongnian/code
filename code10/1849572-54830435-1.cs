    public class Layer_orderer : MonoBehaviour 
    {
        public float y_pos;
        private SpriteRenderer _spriteRenderer;
    
        private void Awake() 
        {
            _spriteRenderer = GetComponent<SpriteRenderer>().sortingOrde
        }
    
        private void Update() 
        {
            // for single values this is easier to read/write
            _spriteRenderer .sortingOrder = transform.position.y > y_pos ? 1 : 3;
        }
    }
