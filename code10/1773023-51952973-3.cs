    public GameObject groupHolder;
    public float groupHolderY = 100f;
    public Vector3 groupPos;
    protected bool moved = false;
    ...
    if(Input.GetKeyUp("down"))
        moved = false;
    if(Input.GetKeyDown("down") && !moved)
    {
        moved = true;
        //groupHolder.transform.position = new Vector3(transform.position.x, 20, transform.position.z);
        groupPos = groupHolder.transform.position;
        float newX = groupHolder.transform.position.x;
        float newY = groupHolder.transform.position.y - 150f;
        float newZ = groupHolder.transform.position.z;
        groupHolder.transform.position = new Vector3(newX, newY, newZ);
    }
