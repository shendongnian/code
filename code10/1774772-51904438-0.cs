    bool SHOULD_CAST_RAY;
    bool USE_EXTERNAL_ORIGINATING_TOUCH_POS;
    Vector3 EXTERNAL_ORIGINATING_TOUCH_POS;
     
    public void LateUpdate()
    {
        if (SHOULD_CAST_RAY)
        {
            if (USE_EXTERNAL_ORIGINATING_TOUCH_POS && EXTERNAL_ORIGINATING_TOUCH_POS.z < 0) { return; }
     
            RaycastHit hit;
            Vector3 screenPoint = Input.mousePresent ? Input.mousePosition : Vector3.zero;
            Vector3 viewportPoint = USE_EXTERNAL_ORIGINATING_TOUCH_POS ? RigsCamera.ScreenToViewportPoint(EXTERNAL_ORIGINATING_TOUCH_POS) : Vector3.zero;
     
            if (Physics.Raycast(
                USE_EXTERNAL_ORIGINATING_TOUCH_POS
                    ? RigsCamera.ViewportPointToRay(new Vector3(viewportPoint.x, 1 - viewportPoint.y, 0))
                    : RigsCamera.ScreenPointToRay(screenPoint),
                out hit,
                CameraRigControllerScript.CameraDistanceMax * 1.5f,
                1 << 10
            )) {
                if (CURRENT_SELECTION == null)
                {
                    CURRENT_SELECTION = UnsafeGetModelInstantiationFromRaycast(hit);
                    ApplySelectionIndication();
                }
                else if (!IsAlreadySelected(hit))
                {
                    RemoveSelectionIndication();
                    CURRENT_SELECTION = UnsafeGetModelInstantiationFromRaycast(hit);
                    ApplySelectionIndication();
                }
                return;
            }
     
            if (CURRENT_SELECTION != null)
            {
                RemoveSelectionIndication();
                CURRENT_SELECTION = null;
            }
        }
    }
     
    // The below methods are used to control the raycasting from React through sendMessage
    public void ClearExternalOriginatingTouchPosition()
    {
        EXTERNAL_ORIGINATING_TOUCH_POS = new Vector3(0, 0, -1f);
        USE_EXTERNAL_ORIGINATING_TOUCH_POS = false;
    }
     
    public void DisableRaycasting()
    {
        SHOULD_CAST_RAY = false;
        RemoveSelectionIndication();
        CURRENT_SELECTION = null;
    }
     
    public void EnableRaycasting()
    {
        SHOULD_CAST_RAY = true;
    }
     
    public void SetExternalOriginatingTouchPosition(string csv)
    {
        string[] pos = csv.Split(',');
        EXTERNAL_ORIGINATING_TOUCH_POS = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), 0);
        USE_EXTERNAL_ORIGINATING_TOUCH_POS = true;
    }
