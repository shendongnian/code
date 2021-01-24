    public class SpriteDetector : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Color normalColor = Color.white;
        public Color highlightedColor = Color.yellow;
    
        SpriteRenderer sp;
    
        void Start()
        {
            sp = GetComponent<SpriteRenderer>();
    
            addPhysics2DRaycaster();
        }
    
        void addPhysics2DRaycaster()
        {
            Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
            if (physicsRaycaster == null)
            {
                Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
            }
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            sp.color = highlightedColor;
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            sp.color = normalColor;
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        }
    }
