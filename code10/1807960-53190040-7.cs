    private float distance = 0.5f;
    private float offset = 0.5f;
    void Update()
    {
        RaycastHit hit;
        Ray footstepRay = new Ray(transform.position + (Vector3.up * offset), Vector3.down); // FIX: added an offset
        if(Physics.Raycast(footstepRay, out hit, distance + offset, LayerMask.GetMask("Ground", "Platform"))) // FIX: added a LayerMask
        {
            if(hit.collider.tag == "Ground")
            {
                Debug.Log ("Player is standing on the ground");
            }
            else if(hit.collider.tag == "Platform")
            {
                Debug.Log ("Player is standing on the platform");
            }
        }
    }
