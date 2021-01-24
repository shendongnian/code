    public class UIDragableScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool allowBeginDrag;
    
        public void OnBeginDrag(PointerEventData eventData)
        {
            if(!enableBegin) return; 
        
            // ...
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            // ...
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
            // ...
        }
    }
