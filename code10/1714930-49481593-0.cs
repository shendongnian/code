    public List<string> _ValidTargetTags = new List<string> { "Wall" };
    public void CheckNearbyArea()
    {
        //Each of the nearby items will be checked to see if they are a wall or other valid target.
        Collider[] ObjectsStruck = ScanForItems(GetComponent<SphereCollider>());
        foreach (var o in ObjectsStruck)
        {
            if (_ValidTargetTags.Contains(o.gameObject.tag))
            {
                //If wall or other valid target
                //Check where wall is placed
                //Act according to wall position.
            }
        }
    }
    ///The method below should find a list of all items inside a spherecollider of the object you are pushing.
    Collider[] ScanForItems(SphereCollider sphereCollider)
    {
        Vector3 center = sphereCollider.transform.position + sphereCollider.center;
        float radius = sphereCollider.radius;
        Collider[] allOverlappingColliders = Physics.OverlapSphere(center, radius);
        return allOverlappingColliders;
    }
