    void Update ()
    {
        attackStyleSwitchRadius = colRef.radius;
        playerCenter = colRef.transform.position;
    
    	var range = Vector3.Distance(Input.mousePosition, Camera.main.WorldToScreenPoint(playerCenter));    
        var inside = range < attackStyleSwitchRadius;
    
    	meleeMode = inside;
        rangeMode = !inside;
    }
