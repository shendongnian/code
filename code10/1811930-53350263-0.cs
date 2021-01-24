    public class PrefabObject: MonoBehaviour {
        
            public BoxCollider2D boxCollider;
        
        	private void Start()
            {
                this.boxCollider = this.GetComponent<BoxCollider2D>();
            }
        }
