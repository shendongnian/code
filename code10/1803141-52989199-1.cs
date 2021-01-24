    RectTransform rectT;
    
    	void Start()
        {
            EventTrigger trigger = GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.Drag;
            entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry);
    		rectT = GetComponent<RectTransform>();
        }
    
        public void OnDragDelegate(PointerEventData data)
        {
    		rectT.anchoredPosition = data.position;
    
        }
