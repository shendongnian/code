    using UnityEngine;
    using UnityEngine.EventSystems;
    
    [System.Serializable]
    public class PointerEvent : UnityEngine.Events.UnityEvent<PointerEventData> {} ;
    
    public class PointerDownHandler : MonoBehaviour, IPointerDownHandler
    {
        public PointerEvent OnPointerDownEvent ;
        public void OnPointerDown(PointerEventData data)
        {
            if( OnPointerDownEvent != null )
                OnPointerDownEvent.Invoke( data ) ;
        }
    }
----
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    public class Area : MonoBehaviour
    {
        public PointerDownHandler PointerDownHandler;
    
        private void Start()
        {
            OnPointerDownEvent.AddListener( OnPointerDown ) ;
        }
    
        public void OnPointerDown(PointerEventData data){ //some code...}
    }
