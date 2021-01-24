    public class ClickCountDetector : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            int clickCount = eventData.clickCount;
    
            if (clickCount == 1)
                OnSingleClick();
            else if (clickCount == 2)
                OnDoubleClick();
            else if (clickCount > 2)
                OnMultiClick();
        }
    
        void OnSingleClick()
        {
            Debug.Log("Single Clicked");
        }
    
        void OnDoubleClick()
        {
            Debug.Log("Double Clicked");
        }
    
        void OnMultiClick()
        {
            Debug.Log("MultiClick Clicked");
        }
    }
