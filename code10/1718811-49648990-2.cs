    void Update ()
    {
        attackStyleSwitchRadius = colRef.radius;
        playerCenter = colRef.transform.position;
    
    	var mouse = Input.mousePosition;
		mouse.z = Vector3.Distance(Camera.main.transform.position, playerCenter);
		var range = Vector3.Distance(Camera.main.ScreenToWorldPoint(mouse), playerCenter);    
        var inside = range < attackStyleSwitchRadius;
    
    	meleeMode = inside;
        rangeMode = !inside;
    }
