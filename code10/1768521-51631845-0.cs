    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X") * 20f * Mathf.Deg2Rad;
            transform.RotateAround(Vector3.up, -rotationX);
        }
    }
