    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
      public Transform parentToReturnTo = null;
      public Transform placeHolderParent = null;
      public void OnBeginDrag(PointerEventData eventData)
      {
          // disable 'raycast target' for your draggable object
          GetComponent<Image>().raycastTarget = false;
    
          parentToReturnTo = transform.parent;
      }
      public void OnDrag(PointerEventData eventData)
      {
          transform.position = eventData.position;
      }
      public void OnEndDrag(PointerEventData eventData)
      {
          // enable it back when drag is over
          GetComponent<Image>().raycastTarget = true;
    
          transform.position = parentToReturnTo.position;
      }
    }
