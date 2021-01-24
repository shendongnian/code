    using System.Linq;
    private float distance = 0.5f;
    private float yOffset = 0.5f;
    private float playerRadius = 0.3f;
    void Update()
    {
        List<RaycastHit> allHits = new List<RaycastHit>();
        DetectGround(allHits, Vector3.zero);
        const int rays = 10;
        for (int i = 0; i < rays; ++i)
        {
            float angle = (360.0f / rays) * i;
            Vector3 posOffset = Quaternion.AngleAxis(angle, Vector3.up) * (Vector3.forward * playerRadius);
            DetectGround(allHits, posOffset);
        }
        if (allHits.Any())
        {
            RaycastHit closestHit = allHits.OrderBy(hit => hit.distance).First();
            OnFound(closestHit.collider.tag);
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
    void DetectGround(List<RaycastHit> hits, Vector3 posOffset)
    {
        Ray footstepRay = new Ray(transform.position + posOffset + (Vector3.up * yOffset), Vector3.down); // FIX: added an offset
        Debug.DrawLine(footstepRay.origin, footstepRay.origin + (footstepRay.direction * (distance + yOffset)), Color.red);
        hits.AddRange(Physics.RaycastAll(footstepRay, distance + yOffset, LayerMask.GetMask("Ground", "Platform")));
    }
