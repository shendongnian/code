    using UnityEngine;
    using UnityEngine.EventSystems;
    
    public class MoveOnMouseDrag : MonoBehaviour {
    
    	public float halfDistance;
    
    	void Start()
        {
            EventTrigger trigger = GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.Drag;
            entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry);
        }
    
        public void OnDragDelegate(PointerEventData data)
        {
    		float distanceFromCamera = Vector3.Distance(Camera.main.transform.position, transform.position);
    		var newPos = Camera.main.ScreenToWorldPoint(new Vector3(data.position.x, data.position.y, distanceFromCamera));
    
    		transform.position = new Vector3(Mathf.Clamp(newPos.x, -halfDistance, halfDistance),
    		                                 transform.position.y,
    										 transform.position.z);
        }
    }
