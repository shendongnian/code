    public class StayQuadratic : MonoBehaviour
    {
        private RectTransform rectTransform;
    
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
    
        private void Update()
        {
            rectTransform.sizeDelta = Vector2.one * rectTransform.rect.width;
        }
    }
