    public class UIDragableScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool allowBeginDrag;
    
        public void OnBeginDrag(PointerEventData eventData)
        {
            if(!allowBeginDrag) return;
        
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
