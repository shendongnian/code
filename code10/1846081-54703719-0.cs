    void Start()
    {
        lr = new GameObject().AddComponent<LineRenderer>();
        lr.gameObject.SetParent(transform, false);
        // just to be sure reset position and rotation as well
        lr.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    
        lr2 = new GameObject().AddComponent<LineRenderer>();
        lr2.gameObject.SetParent(transform, false);
        // just to be sure reset position and rotation as well
        lr2.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    
        lr3 = new GameObject().AddComponent<LineRenderer>();
        lr3.gameObject.SetParent(transform, false);
        // just to be sure reset position and rotation as well
        lr3.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    
        lr4 = new GameObject().AddComponent<LineRenderer>();
        lr4.gameObject.SetParent(transform, false);
        // just to be sure reset position and rotation as well
        lr4.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
