    using UnityEngine;
    using UnityEngine.EventSystems;
    
    public class Example : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool isDown;
        public bool isUp;
    
        //Detect current clicks on the GameObject (the one with the script attached)
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            isDown = true;
        }
    
        //Detect if clicks are no longer registering
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            isUp = true;
        }
    
        // reset both in LateUpdate
        private void LateUpdate()
        {
            isDown = false;
            isUp = false;
        }
    }
