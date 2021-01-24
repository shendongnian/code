    public float rotationSpeed = 100f;
    
    public void rotateClockwise()
        {
            transform.Rotate(0f, 0f, (rotationSpeed * Time.deltaTime));
        }
    
    public void rotateCtrClockwise()
        {
            transfrom.Rotate(0f, 0f, -(rotationSpeed * Time.deltaTime));
        }
