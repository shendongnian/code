    public class ButtonOverlapTest : MonoBehaviour {
    
        RectTransform rectTransform;
        Rect otherRect = new Rect(20, 20, 100, 100);
    
        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }
    
        public void ButtonClicked()
        {
            if (rectTransform.rect.Overlaps(otherRect))
            {
                Debug.Log("Overlap!");
            }
   
        }
    }
