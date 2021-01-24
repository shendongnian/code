    // rotation speed in degrees per second
    public float RotationSpeed;
    void Update()
    {
        FixOrientation();
    }
    void FixOrientation()
    {
        if (transform.up != -GetGravityDirection())
        {
            // Get the current angle between the up axis and your negative gravity vector
            var difference = Vector3.Angle(transform.up, -GetGravityDirection());
            // This simply assures you don't overshoot and rotate more than required 
            // to avoid a back-forward loop
            // also use Time.deltaTime for a frame-independent rotation speed
            var maxStep = Mathf.Min(difference, RotationSpeed * Time.deltaTime);
            // you only want ot rotate around local Z axis
            // Space.Self makes sure you use the local axis
            transform.Rotate(0, 0, maxStep, Space.Self);
            }
        }
 
