    private float distance = 0.5f;
    private float yOffset = 0.5f;
    private float playerRadius = 0.3f;
    void Update()
    {
        string hitTag = DetectGround(Vector3.zero);
        if (hitTag != null)
        {
            OnFound(hitTag);
            return;
        }
        const int rays = 10;
        for (int i = 0; i < rays; ++i)
        {
            float angle = (360.0f / rays) * i;
            Vector3 posOffset = Quaternion.AngleAxis(Vector3.up, angle) * (Vector3.forward * playerRadius);
            hitTag = DetectGround(posOffset);
            if (hitTag != null)
            {
                OnFound(hitTag);
                return;
            }
    }
    void OnFound(string tag)
    {
        if(tag == "Ground")
        {
            Debug.Log ("Player is standing on the ground");
        }
        else if(tag == "Platform")
        {
            Debug.Log ("Player is standing on the platform");
        }
    }
    string DetectGround(Vector3 posOffset)
    {
        RaycastHit hit;
        Ray footstepRay = new Ray(transform.position + posOffset + (Vector3.up * yOffset), Vector3.down); // FIX: added an offset
        if(Physics.Raycast(footstepRay, out hit, distance + yOffset, LayerMask.GetMask("Ground", "Platform"))) // FIX: added a LayerMask
        {
            return hit.collider.tag;
        }
        return null;
    }
