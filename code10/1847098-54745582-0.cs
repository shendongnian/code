    using UnityEngine;
    using UnityEngine.EventSystems;
     
    public class DestroyOnRightClick : MonoBehaviour, IPointerClickHandler 
    {
        public void OnPointerClick (PointerEventData eventData) 
        {
            if (eventData.button == PointerEventData.InputButton.Right) 
            {
                 Debug.Log ("Right Mouse Button Clicked on: " + name);
                 Destroy(gameObject);
            }
        }
    }
    
